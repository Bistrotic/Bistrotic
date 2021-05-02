namespace Bistrotic.Domain.Communication
{
    using System;
    using System.Collections.Generic;

    public sealed class Email
    {
        public IReadOnlyList<EmailAttachment> Attachments { get; init; } = Array.Empty<EmailAttachment>();

        public string? Body { get; init; }

        public IReadOnlyList<string> CopyToRecipients { get; init; } = new List<string>();

        public string Sender { get; init; } = string.Empty;

        public string? Subject { get; init; }

        public IReadOnlyList<string> ToRecipients { get; init; } = new List<string>();
    }
}