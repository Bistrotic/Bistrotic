namespace Bistrotic.UblDocuments.Events
{
    using Bistrotic.Domain.Contracts.Events;
    using Bistrotic.UblDocuments.Types.Aggregates;

    using ProtoBuf;

    [Event]
    [ProtoContract]
    public sealed class UblInvoiceSubmitted
    {
        [ProtoMember(1)]
        public Invoice Invoice { get; set; } = new();
    }
}