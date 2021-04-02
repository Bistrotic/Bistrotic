using System.Collections.Generic;

using Bistrotic.Emails.Domain.Events;
using Bistrotic.Emails.Domain.ValueTypes;

namespace Bistrotic.Emails.Domain
{
    internal interface IEmailState
    {
        List<Attachment> Attachments { get; set; }
        string Body { get; set; }
        List<string> CopyToRecipients { get; set; }
        string Recipient { get; set; }
        string Sender { get; set; }
        string Subject { get; set; }
        List<string> ToRecipients { get; set; }

        void Apply(EmailReceived @event);
    }
}