namespace Bistrotic.Emails.Server.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Emails.Domain;
    using Bistrotic.Emails.Domain.Events;
    using Bistrotic.Emails.Domain.Exceptions;
    using Bistrotic.Emails.Domain.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class EmailTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("                          ")]
        public void Id_undefined_should_throw_invalid_email_id_exception(string id)
        {
#pragma warning disable CA1806 // Do not ignore method results
            Action newEmail = () => new Email(id, new EmailState());
#pragma warning restore CA1806 // Do not ignore method results
            newEmail.Should().Throw<EmailStateNotInitializedException>();
        }

        [Fact]
        public async Task ReceiveEmail_publishes_MailReceived_event()
        {
            var attachments = new Attachment[]
            {
                    new ("File1", "ABCD==" ),
                    new ("File2", "FFEE==" ),
                    new ("File3", "123456789==")
            };
            var emailState = new EmailState();
            var email = new Email("123456", emailState);
            var events = await email.Receive
            (
                sender: "toto@titi.net",
                attachments: attachments,
                body: "Hello world!",
                copyToRecipients: new[] { "mail1@tot.com", "mail2@titi.com" },
                recipient: "reci@dada.com",
                subject: "I am testing",
                toRecipients: new[] { "ggg@hello.com", "ggghh@nan.info", "reci@dada.com" }
            );
            events.Should().HaveCount(1);
            var @event = events.FirstOrDefault();
            @event.Should().BeOfType<EmailReceived>();
            EmailReceived received = (EmailReceived)@event;
            received.Attachments.Should().BeEquivalentTo(attachments);
            received.Body.Should().Be("Hello world!");
            received.CopyToRecipients.Should().BeEquivalentTo(new[] { "mail1@tot.com", "mail2@titi.com" });
            received.EmailId.Should().Be("kllhh544");
            received.Recipient.Should().Be("reci@dada.com");
            received.Subject.Should().Be("I am testing");
            received.ToRecipients.Should().BeEquivalentTo(new[] { "ggg@hello.com", "ggghh@nan.info", "reci@dada.com" });
        }

        [Fact]
        public void State_null_should_throw_not_initialized_exception()
        {
#pragma warning disable CA1806 // Do not ignore method results
            Action newEmail = () => new Email("id123", null);
#pragma warning restore CA1806 // Do not ignore method results
            newEmail.Should().Throw<EmailStateNotInitializedException>();
        }
    }
}