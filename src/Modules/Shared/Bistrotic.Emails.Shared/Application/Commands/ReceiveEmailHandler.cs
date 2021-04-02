using System.Threading.Tasks;

using Bistrotic.Application.Commands;
using Bistrotic.Application.Messages;
using Bistrotic.Application.Repositories;
using Bistrotic.Emails.Domain;

namespace Bistrotic.Emails.Application.Commands
{
    [CommandHandler(Command = typeof(ReceiveEmail))]
    internal class ReceiveEmailHandler
    {
        private readonly IRepository<EmailState> _repository;

        public ReceiveEmailHandler(IRepository<EmailState> repository)
        {
            _repository = repository;
        }

        public async Task Handle(Envelope<ReceiveEmail> envelope)
        {
            var id = envelope.Message.EmailId;
            var state = await _repository.CreateNew(id);
            var email = new Email(id, state);
            var command = envelope.Message;
            await _repository.Save(id,
                new RepositoryData<EmailState>(
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
    }
}