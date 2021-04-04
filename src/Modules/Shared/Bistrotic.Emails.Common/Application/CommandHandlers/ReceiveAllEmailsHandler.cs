namespace Bistrotic.Emails.Application.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Application.Services;
    using Bistrotic.Emails.Domain.States;

    [CommandHandler(Command = typeof(ReceiveAllEmails))]
    public class ReceiveAllEmailsHandler : ICommandHandler<ReceiveAllEmails>
    {
        private readonly ICommandBus _commandBus;
        private readonly IMailboxService _mailService;
        private readonly IRepository<IEmailState> _repository;

        public ReceiveAllEmailsHandler(ICommandBus commandBus, IMailboxService mailService, IRepository<IEmailState> repository)
        {
            _commandBus = commandBus;
            _mailService = mailService;
            _repository = repository;
        }

        public async Task Handle(Envelope<ReceiveAllEmails> envelope, CancellationToken cancellationToken = default)
        {
            foreach (var message in await _mailService.GetUserMails(envelope.Message.Recipient, cancellationToken))
            {
                if (!await _repository.Exists(message.EmailId, cancellationToken))
                {
                    await _commandBus.Send(new Envelope<ReceiveEmail>(message, new MessageId(), envelope), cancellationToken);
                }
            }
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<ReceiveAllEmails>(envelope), cancellationToken);
    }
}