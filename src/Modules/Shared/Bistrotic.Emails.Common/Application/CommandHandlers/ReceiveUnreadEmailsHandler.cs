namespace Bistrotic.Emails.Application.CommandHandlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Messages;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Application.Mappers;
    using Bistrotic.Infrastructure.MicrosoftGraph;

    [CommandHandler(Command = typeof(ReceiveUnreadEmails))]
    public class ReceiveUnreadEmailsHandler
    {
        private readonly ICommandBus _commandBus;
        private readonly IGraphService _mailService;

        public ReceiveUnreadEmailsHandler(
            ICommandBus commandBus,
            IGraphService mailService)
        {
            _commandBus = commandBus;
            _mailService = mailService;
        }

        public async Task Handle(Envelope<ReceiveAllEmails> envelope)
        {
            foreach (var message in await _mailService.GetUserMails(envelope.Message.Recipient))
            {
                var receiveEmail = message.MapToReceiveEmail();

                await _commandBus.Send(new Envelope<ReceiveEmail>(receiveEmail, new MessageId(), envelope));
            }
        }
    }
}