﻿namespace Bistrotic.DataIntegrations.Application.CommandHandlers
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Application.Commands;
    using Bistrotic.DataIntegrations.Common.Domain.ValueTypes;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Emails.Contracts.Events;

    using Microsoft.Extensions.Logging;

    using SharpCompress.Archives.Zip;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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
                await _commandBus.Send(GetAttachments(envelope), cancellationToken);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Data integration email received event handler error : {e.Message}.\nMessageId={envelope.MessageId}; EmailId={envelope.Message.EmailId}; Subject={envelope.Message.Subject}");
                throw;
            }
        }
        private static Envelope<SubmitDataIntegration>? GetSubmitMessage(Envelope<EmailReceived> envelope, string name, string description, string content)
        {
            string? fileType = Path.GetExtension(name.ToUpperInvariant())
            switch
            {
                ".CSV" => nameof(FileType.Csv),
                ".TXT" => nameof(FileType.Csv),
                ".XML" => nameof(FileType.Xml),
                ".XLS" => nameof(FileType.Xls),
                ".XLSX" => nameof(FileType.Xlsx),
                _ => null
            };
            return (fileType == null) ? null : new(new SubmitDataIntegration
            {
                DataIntegrationId = envelope.Message.EmailId + "/" + name,
                Name = envelope.Message.Subject + " - " + name,
                Description = description,
                DocumentName = name,
                DocumentType = fileType,
                Document = content
            }, new MessageId(), envelope);
        }
        private static List<Envelope<SubmitDataIntegration>> GetAttachments(Envelope<EmailReceived> envelope)
        {
            List<Envelope<SubmitDataIntegration>> list = new();
            var description = $"Mailbox : {envelope.Message.Recipient}\nFrom : {envelope.Message.Sender}\nBody :\n{envelope.Message.Body}";
            foreach (var attachment in envelope.Message.Attachments)
            {
                string? fileExt = Path.GetExtension(attachment.Name.ToUpperInvariant());
                if (fileExt == ".ZIP")
                {
                    using MemoryStream stream = new(Convert.FromBase64String(attachment.Content));
                    using var zip = ZipArchive.Open(stream);
                    foreach (var entry in zip.Entries.Where(p => p.IsDirectory == false))
                    {
                        using var entryStream = entry.OpenEntryStream();
                        using MemoryStream content = new();
                        entryStream.CopyTo(content);
                        content.Flush();
                        content.Position = 0;
                        string base64Content = Convert.ToBase64String(content.GetBuffer(), 0, (int)content.Length);
                        // TODO file name
                        var message = GetSubmitMessage(envelope,
                                                       entry.Key,
                                                       description,
                                                       base64Content);
                        if (message == null)
                        {
                            continue;
                        }
                        list.Add(message);
                    }
                }
                else
                {
                    var message = GetSubmitMessage(envelope, attachment.Name, description, attachment.Content);
                    if (message == null)
                    {
                        continue;
                    }
                    list.Add(message);
                }

            }
            return list;
        }
    }
}