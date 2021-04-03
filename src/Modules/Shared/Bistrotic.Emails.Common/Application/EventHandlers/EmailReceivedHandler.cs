namespace Bistrotic.Emails.Application.EventHandlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Emails.Contracts.Events;
    using Bistrotic.Infrastructure.MicrosoftGraph;

    [EventHandler(Event = typeof(EmailReceived))]
    public class EmailReceivedHandler
    {
        private readonly IGraphService _mailService;

        public EmailReceivedHandler(IGraphService mailService)
        {
            _mailService = mailService;
        }

        public Task Handle(Envelope<EmailReceived> envelope)
        {
            return _mailService.SetEmailAsRead(envelope.Message.Recipient, envelope.Message.EmailId);
        }
    }
}