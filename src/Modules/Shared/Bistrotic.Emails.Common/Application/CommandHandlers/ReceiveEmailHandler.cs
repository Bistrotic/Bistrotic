namespace Bistrotic.Emails.Application.CommandHandlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Domain;
    using Bistrotic.Emails.Domain.States;

    using Microsoft.Extensions.Logging;

    [CommandHandler(Command = typeof(ReceiveEmail))]
    public class ReceiveEmailHandler
    {
        private readonly ILogger<ReceiveEmailHandler> _logger;
        private readonly IRepository<IEmailState> _repository;

        public ReceiveEmailHandler(IRepository<IEmailState> repository, ILogger<ReceiveEmailHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task Handle(Envelope<ReceiveEmail> envelope)
        {
            var id = envelope.Message.EmailId;
            try
            {
                var state = await _repository.CreateNew(id);
                var email = new Email(id, state);
                var command = envelope.Message;
                await _repository.Save(id,
                    new RepositoryData<IEmailState>(
                        envelope,
                        state,
                        await email.Receive(
                                recipient: command.Recipient,
                                subject: command.Subject,
                                body: command.Body,
                                sender: command.Sender,
                                toRecipients: command.ToRecipients,
                                copyToRecipients: command.CopyToRecipients,
                                attachments: command.Attachments
                    )));
            }
            catch (DuplicateRepositoryStateException)
            {
                _logger.LogWarning($"Duplicate email found in mailbox '{envelope.Message.Recipient}' : Id='{envelope.Message.EmailId}', Subject='{envelope.Message.Subject}', MessageId='{envelope.MessageId}'.");
            }
        }
    }
}