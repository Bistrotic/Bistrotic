namespace Bistrotic.Emails.Application.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Domain;
    using Bistrotic.Emails.Domain.States;

    using Microsoft.Extensions.Logging;

    [CommandHandler(Command = typeof(ReceiveEmail))]
    public class ReceiveEmailHandler : ICommandHandler<ReceiveEmail>
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<ReceiveEmailHandler> _logger;
        private readonly IRepository<IEmailState> _repository;

        public ReceiveEmailHandler(IEventBus eventBus, IRepository<IEmailState> repository, ILogger<ReceiveEmailHandler> logger)
        {
            _eventBus = eventBus;
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
                await _repository.Save(id,
                    new RepositoryData<IEmailState>(
                        envelope,
                        state,
                        events), cancellationToken);
                foreach (var e in events)
                {
                    await _eventBus.Publish(new Envelope(e, new MessageId(), envelope), cancellationToken);
                }
            }
            catch (DuplicateRepositoryStateException)
            {
                _logger.LogWarning($"Duplicate email found in mailbox '{envelope.Message.Recipient}' : Id='{envelope.Message.EmailId}', Subject='{envelope.Message.Subject}', MessageId='{envelope.MessageId}'.");
            }
        }
    }
}