using System.Collections.Generic;

namespace Bistrotic.Emails.Domain
{
    internal interface IEmailState
    {
        internal List<IEmailAttachement> Attachments { get; }
    }
}