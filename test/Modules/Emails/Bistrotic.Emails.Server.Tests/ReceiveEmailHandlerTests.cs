namespace Bistrotic.Emails.Server.Tests
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Application.CommandHandlers;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Contracts.Events;
    using Bistrotic.Emails.Contracts.ValueTypes;
    using Bistrotic.Emails.Domain.States;

    using Microsoft.Extensions.Logging;

    using Moq;

    using Xunit;

    public class ReceiveEmailHandlerTests
    {
        [Fact]
        public async Task Handle_publishes_EmailReceived_event()
        {
            var loggerMock = new Mock<ILogger<ReceiveEmailHandler>>();
            var eventBusMock = new Mock<IEventBus>();
            eventBusMock.Setup(x => x.Publish(
                    It.IsAny<IEnvelope>(),
                    It.IsAny<CancellationToken>()
                ));
            var receive = CreateReceiveEmail();
            var mockRepository = new Mock<IRepository<IEmailState>>();
            mockRepository
                .Setup(x => x.Save(
                    It.IsAny<string>(),
                    It.IsAny<IRepositoryData<IEmailState>>(),
                    It.IsAny<CancellationToken>()
                ))
                .Returns(Task.FromResult<IEmailState>(new EmailState()));
            var repository = mockRepository.Object;
            var handler = new ReceiveEmailHandler(eventBusMock.Object, repository, loggerMock.Object);
            await handler.Handle(new Envelope<ReceiveEmail>(
                receive,
                "msgid123",
                "test user",
                DateTimeOffset.Now
                ));
            eventBusMock.Verify(x => x.Publish(
                    It.Is<IEnvelope>(p => p.Message.GetType() == typeof(EmailReceived)),
                    It.IsAny<CancellationToken>()
                ));
            mockRepository.Verify(x => x.Save(
                receive.EmailId,
                It.Is<IRepositoryData<IEmailState>>(p =>
                    p.State.CopyToRecipients.Count() == receive.CopyToRecipients.Count() &&
                    p.State.ToRecipients.Count() == receive.ToRecipients.Count() &&
                    p.State.Attachments.Count() == receive.Attachments.Count() &&
                    p.State.Body == receive.Body &&
                    p.State.Recipient == receive.Recipient &&
                    p.State.Subject == receive.Subject &&
                    p.State.Sender == receive.Sender &&
                    p.Events.Count() == 1 &&
                    p.Events.First().GetType() == typeof(EmailReceived) &&
                    ((EmailReceived)p.Events.First()).EmailId == receive.EmailId &&
                    ((EmailReceived)p.Events.First()).Body == receive.Body &&
                    ((EmailReceived)p.Events.First()).Sender == receive.Sender &&
                    ((EmailReceived)p.Events.First()).Recipient == receive.Recipient &&
                    ((EmailReceived)p.Events.First()).Subject == receive.Subject &&
                    ((EmailReceived)p.Events.First()).CopyToRecipients.Count() == receive.CopyToRecipients.Count() &&
                    ((EmailReceived)p.Events.First()).ToRecipients.Count() == receive.ToRecipients.Count() &&
                    ((EmailReceived)p.Events.First()).Attachments.Count() == receive.Attachments.Count()
                ), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        private static ReceiveEmail CreateReceiveEmail()
        {
            var attachments = new Attachment[]
            {
                new (){Name = "File1", Content = "ABCD==" },
                new (){Name = "File2", Content = "FFEE==" },
                new (){Name = "File3", Content = "123456789==" }
            };
            return new ReceiveEmail
            {
                EmailId = "Email123",
                Sender = "toto@titi.net",
                Attachments = attachments,
                Body = "Hello world!",
                CopyToRecipients = new[] { "mail1@tot.com", "mail2@titi.com" },
                Recipient = "reci@dada.com",
                Subject = "I am testing",
                ToRecipients = new[] { "ggg@hello.com", "ggghh@nan.info", "reci@dada.com" }
            };
        }
    }
}