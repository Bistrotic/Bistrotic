using System;
using System.Collections.Generic;
using System.Linq;

using Bistrotic.Emails.Domain.ValueTypes;

namespace Bistrotic.Emails.Domain.Events
{
    internal class EmailReceived
    {
        public EmailReceived(
            EmailAddress recipient,
            EmailId emailId,
            string subject,
            string body,
            string sender,
            IEnumerable<EmailAddress> toRecipients,
            IEnumerable<EmailAddress> copyToRecipients,
            IEnumerable<Attachment> attachements
            )
        {
            Recipient = recipient;
            Subject = subject;
            Body = body;
            Sender = sender;
            EmailId = emailId;
            ToRecipients = new List<string>(toRecipients.Select(p => p.Value));
            CopyToRecipients = new List<string>(copyToRecipients.Select(p => p.Value));
            Attachments = attachements;
        }
        public string Subject { get; init; } = string.Empty;
        public string Body { get; init; } = string.Empty;
        public string Sender { get; init; } = string.Empty;
        public IEnumerable<string> ToRecipients { get; init; } = Array.Empty<string>();
        public IEnumerable<string> CopyToRecipients { get; init; } = Array.Empty<string>();
        public IEnumerable<Attachment> Attachments { get; init; } = Array.Empty<Attachment>();
        public string Recipient { get; init; } = string.Empty;
        public string EmailId { get; init; } = string.Empty;
    }
}