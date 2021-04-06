namespace Bistrotic.DataIntegrations.Application.CommandHandlers
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Application.Commands;
    using Bistrotic.DataIntegrations.Common.Domain.ValueTypes;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Emails.Contracts.Events;

    using Microsoft.Extensions.Logging;

    [EventHandler(Event = typeof(EmailReceived))]
    public class EmailReceivedHandler : IEventHandler<EmailReceived>
    {
        private readonly ICommandBus _commandBus;
        private readonly ILogger<EmailReceivedHandler> _logger;

        public EmailReceivedHandler(ICommandBus commandBus, ILogger<EmailReceivedHandler> logger)
        {
            _commandBus = commandBus;
            _logger = logger;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
           => Handle(new Envelope<EmailReceived>(envelope), cancellationToken);

        public async Task Handle(Envelope<EmailReceived> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                var description = $"Mailbox : {envelope.Message.Recipient}\nFrom : {envelope.Message.Sender}\nBody :\n{envelope.Message.Body}";
                foreach (var attachment in envelope.Message.Attachments)
                {
                    FileType? fileType = Path.GetExtension(attachment.Name.ToUpperInvariant())
                        switch
                    {
                        ".CSV" => FileType.Csv,
                        ".TXT" => FileType.Csv,
                        ".XML" => FileType.Xml,
                        ".XLS" => FileType.Xls,
                        ".XLSX" => FileType.Xlsx,
                        _ => null
                    };
                    if (fileType == null)
                    {
                        continue;
                    }
                    await _commandBus.Send(new Envelope<SubmitDataIntegration>(
                        new SubmitDataIntegration
                        {
                            DataIntegrationId = envelope.Message.EmailId + "/" + attachment.Name,
                            Name = envelope.Message.Subject + " - " + attachment.Name,
                            Description = description,
                            DocumentName = attachment.Name,
                            DocumentType = fileType?.ToString() ?? string.Empty,
                            Document = attachment.Content
                        }, new MessageId(), envelope), cancellationToken);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Data integration email received event handler error : {e.Message}.\nMessageId={envelope.MessageId}; EmailId={envelope.Message.EmailId}; Subject={envelope.Message.Subject}");
                throw;
            }
        }
    }
}