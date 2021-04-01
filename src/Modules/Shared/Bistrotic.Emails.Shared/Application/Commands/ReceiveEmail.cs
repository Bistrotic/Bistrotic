namespace Bistrotic.Emails.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bistrotic.Application.Commands;
    using Bistrotic.Emails.Domain.ValueTypes;

    [Command]
    internal sealed class ReceiveEmail
    {
        public ReceiveEmail()
        {
        }
        public ReceiveEmail(
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
            AttachmentNames = new List<string>(attachements.Select(p => p.Name));
            AttachmentContents = new List<string?>(attachements.Select(p => p.Content));
        }
        public string Subject { get; init; } = string.Empty;
        public string Body { get; init; } = string.Empty;
        public string Sender { get; init; } = string.Empty;
        public IEnumerable<string> ToRecipients { get; init; } = Array.Empty<string>();
        public IEnumerable<string> CopyToRecipients { get; init; } = Array.Empty<string>();
        public IEnumerable<string> AttachmentNames { get; init; } = Array.Empty<string>();
        public IEnumerable<string?> AttachmentContents { get; init; } = Array.Empty<string?>();
        public string Recipient { get; init; } = string.Empty;
        public string EmailId { get; init; } = string.Empty;
    }
}