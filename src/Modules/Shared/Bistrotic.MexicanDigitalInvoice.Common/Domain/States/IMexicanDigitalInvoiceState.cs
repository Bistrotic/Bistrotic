namespace Bistrotic.MexicanDigitalInvoice.Domain.States
{
    using System.Collections.Generic;

    using Bistrotic.MexicanDigitalInvoice.Aggregates;

    public interface IMexicanDigitalInvoiceState
    {
        Voucher Invoice { get; set; }

        void Apply(IEnumerable<object> events);
    }
}