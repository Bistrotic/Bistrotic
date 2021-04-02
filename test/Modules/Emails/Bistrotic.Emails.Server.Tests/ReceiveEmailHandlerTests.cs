namespace Bistrotic.Emails.Server.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Domain;
    using Bistrotic.Emails.Domain.ValueTypes;

    using Moq;

    using Xunit;

    public class ReceiveEmailHandlerTests
    {
        [Fact]
        public async Task Handle_publishes_EmailReceived_event()
        {
            var receive = CreateReceiveEmail();
            var mockRepository = new Mock<IRepository<IEmailState>>();
            mockRepository
                .Setup(x => x.CreateNew(It.IsAny<string>()))
                .Returns(Task.FromResult<IEmailState>(new EmailState()));
            mockRepository
                .Setup(x => x.Save(
                    It.IsAny<string>(),
                    It.IsAny<IRepositoryData<IEmailState>>()
                ))
                .Returns(Task.FromResult<IEmailState>(new EmailState()));
            var repository = mockRepository.Object;
            var handler = new ReceiveEmailHandler(repository);
            await handler.Handle(new Envelope<ReceiveEmail>(
                receive,
                "msgid123",
                "test user",
                DateTimeOffset.Now
                ));
            mockRepository.Verify(x => x.CreateNew(receive.EmailId), Times.Once);
            mockRepository.Verify(x => x.Save(receive.EmailId, It.Is<IRepositoryData<IEmailState>>(p =>
                        p.State.Attachments.Count == receive.Attachments.Count() &&
                        p.State.Body == receive.Body &&
                        p.State.Recipient == receive.Recipient &&
                        p.State.Subject == receive.Subject &&
                        p.Events.Count() == 1 &&
                        p.Events.First().GetType() == typeof(ReceiveEmail)

                )), Times.Once);
        }

        private static ReceiveEmail CreateReceiveEmail()
        {
            var attachments = new Attachment[]
            {
                    new ("File1", "ABCD==" ),
                    new ("File2", "FFEE==" ),
                    new ("File3", "123456789==")
            };
            return new ReceiveEmail
            (
                emailId: "Email123",
                sender: "toto@titi.net",
                attachments: attachments,
                body: "Hello world!",
                copyToRecipients: new EmailAddress[] { "mail1@tot.com", "mail2@titi.com" },
                recipient: "reci@dada.com",
                subject: "I am testing",
                toRecipients: new EmailAddress[] { "ggg@hello.com", "ggghh@nan.info", "reci@dada.com" }
            );
        }
    }
}