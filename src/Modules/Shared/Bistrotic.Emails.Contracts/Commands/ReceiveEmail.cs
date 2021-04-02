namespace Bistrotic.Emails.Application.Commands
{
    using System.Collections.Generic;

    using Bistrotic.Domain.Contracts.Commands;
    using Bistrotic.Emails.Contracts.ValueTypes;

    using ProtoBuf;

    [Command]
    [ProtoContract(SkipConstructor = true)]
    public sealed class ReceiveEmail
    {
        [ProtoMember(100)]
        public IEnumerable<Attachment> Attachments { get; set; }

        [ProtoMember(7)]
        public string Body { get; set; }

        [ProtoMember(5)]
        public IEnumerable<string> CopyToRecipients { get; set; }

        [ProtoMember(1)]
        public string EmailId { get; set; }

        [ProtoMember(2)]
        public string Recipient { get; set; }

        [ProtoMember(3)]
        public string Sender { get; set; }

        [ProtoMember(6)]
        public string Subject { get; set; }

        [ProtoMember(4)]
        public IEnumerable<string> ToRecipients { get; set; }
    }
}