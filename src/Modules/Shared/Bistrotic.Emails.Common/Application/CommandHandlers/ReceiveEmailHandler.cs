namespace Bistrotic.Emails.Application.CommandHandlers
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Helpers;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Domain;
    using Bistrotic.Emails.Domain.States;

    using Microsoft.Extensions.Logging;

    [CommandHandler(Command = typeof(ReceiveEmail))]
    public class ReceiveEmailHandler : ICommandHandler<ReceiveEmail>
    {
        private readonly ILogger<ReceiveEmailHandler> _logger;
        private readonly IRepository<IEmailState> _repository;

        public ReceiveEmailHandler(IRepository<IEmailState> repository, ILogger<ReceiveEmailHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
           => Handle(new Envelope<ReceiveEmail>(envelope), cancellationToken);

        public async Task Handle(Envelope<ReceiveEmail> envelope, CancellationToken cancellationToken = default)
        {
            var id = envelope.Message.EmailId;
            try
            {
                if (await _repository.Exists(id, cancellationToken))
                {
                    throw new DuplicateRepositoryStateException(_repository, id);
                }
                var state = new EmailState();
                var email = new Email(id, state);
                var command = envelope.Message;
                var events = await email.Receive(
                                recipient: command.Recipient,
                                subject: command.Subject,
                                body: command.Body,
                                sender: command.Sender,
                                toRecipients: command.ToRecipients,
                                copyToRecipients: command.CopyToRecipients,
                                attachments: command.Attachments);
                await _repository.SetState(id, envelope.ToMetadata(), state, cancellationToken);
                await _repository.Publish(events.Select(p => new Envelope(p, new Bistrotic.Domain.ValueTypes.MessageId(), envelope)).ToList(), cancellationToken);
                await _repository.Save(cancellationToken);
            }
            catch (DuplicateRepositoryStateException)
            {
                _logger.LogWarning($"Duplicate email found in mailbox '{envelope.Message.Recipient}' : Id='{envelope.Message.EmailId}', Subject='{envelope.Message.Subject}', MessageId='{envelope.MessageId}'.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while handling receive email event. From '{envelope.Message.Recipient}' : Id='{envelope.Message.EmailId}', Subject='{envelope.Message.Subject}', MessageId='{envelope.MessageId}'.");
                throw;
            }
        }
    }
}