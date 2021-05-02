namespace Bistrotic.MexicanDigitalInvoice.Events
{
    using Bistrotic.Domain.Contracts.Events;
    using Bistrotic.MexicanDigitalInvoice.Types.Aggregates;

    using ProtoBuf;

    [Event]
    [ProtoContract]
    public sealed class UblInvoiceSubmitted
    {
        [ProtoMember(1)]
        public Invoice Invoice { get; set; } = new();
    }
}