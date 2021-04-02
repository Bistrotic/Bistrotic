using ProtoBuf;

namespace Bistrotic.Emails.Application.ModelViews
{
    [ProtoContract]
    public sealed class EmailSummaryInformations
    {
        [ProtoMember(1)]
        public string EmailId { get; set; }

        [ProtoMember(2)]
        public string Recipient { get; set; }

        [ProtoMember(3)]
        public string Sender { get; set; }

        [ProtoMember(4)]
        public string Subject { get; set; }
    }
}