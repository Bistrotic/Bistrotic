using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.Emails.Domain.Events;
using Bistrotic.Emails.Domain.ValueTypes;

namespace Bistrotic.Emails.Domain
{
    internal class EmailState : IEmailState
    {
        public List<Attachment> Attachments { get; set; } = new();

        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Sender { get; set; } = string.Empty;
        public List<string> ToRecipients { get; set; } = new();
        public List<string> CopyToRecipients { get; set; } = new();
        public string Recipient { get; set; } = string.Empty;

        public void Apply(EmailReceived @event)
        {
            Subject = @event.Subject;
            Body = @event.Body;
            Sender = @event.Sender;
            ToRecipients = new List<string>(@event.ToRecipients);
            CopyToRecipients = new List<string>(@event.CopyToRecipients);
            Recipient = @event.Recipient;
            Attachments = new List<Attachment>(@event.Attachments);
        }
    }
}