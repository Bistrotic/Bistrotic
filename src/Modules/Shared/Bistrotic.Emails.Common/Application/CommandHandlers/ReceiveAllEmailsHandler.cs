namespace Bistrotic.Emails.Application.CommandHandlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Application.Mappers;
    using Bistrotic.Emails.Domain.States;
    using Bistrotic.Infrastructure.MicrosoftGraph;

    [CommandHandler(Command = typeof(ReceiveAllEmails))]
    public class ReceiveAllEmailsHandler
    {
        private readonly ICommandBus _commandBus;
        private readonly IGraphService _mailService;
        private readonly IRepository<IEmailState> _repository;

        public ReceiveAllEmailsHandler(ICommandBus commandBus, IGraphService mailService, IRepository<IEmailState> repository)
        {
            _commandBus = commandBus;
            _mailService = mailService;
            _repository = repository;
        }

        public async Task Handle(Envelope<ReceiveAllEmails> envelope)
        {
            foreach (var message in await _mailService.GetUserMails(envelope.Message.Recipient))
            {
                var receiveEmail = message.MapToReceiveEmail();
                if (!await _repository.Exists(receiveEmail.EmailId))
                {
                    await _commandBus.Send(new Envelope<ReceiveEmail>(receiveEmail, new MessageId(), envelope));
                }
            }
        }
    }
}