namespace Bistrotic.Emails.Application.EventHandlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Emails.Application.Services;
    using Bistrotic.Emails.Contracts.Events;

    [EventHandler(Event = typeof(EmailReceived))]
    public class EmailReceivedHandler : IEventHandler<EmailReceived>
    {
        private readonly IMailboxService _mailService;

        public EmailReceivedHandler(IMailboxService mailService)
        {
            _mailService = mailService;
        }

        public Task Handle(Envelope<EmailReceived> envelope, CancellationToken cancellationToken = default)
        {
            return _mailService.SetEmailAsRead(envelope.Message.Recipient, envelope.Message.EmailId, cancellationToken);
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<EmailReceived>(envelope), cancellationToken);
    }
}