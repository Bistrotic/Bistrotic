namespace Bistrotic.Emails.Application.ModelViews
{
    using System.Collections.Generic;

    using ProtoBuf;

    [ProtoContract]
    public class EmailDetailedInformations
    {
        [ProtoMember(8)]
        public IEnumerable<string> AttachmentNames { get; set; }

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