namespace Bistrotic.MexicanDigitalInvoice.Events
{
    using Bistrotic.Domain.Contracts.Events;
    using Bistrotic.MexicanDigitalInvoice.Aggregates;

    using ProtoBuf;

    [Event]
    [ProtoContract]
    public sealed class MexicanDigitalInvoiceSubmitted
    {
        [ProtoMember(1)]
        public Voucher Invoice { get; set; } = new();
    }
}