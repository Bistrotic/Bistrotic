using System.Collections.Generic;

using Bistrotic.MexicanDigitalInvoice.Types.Aggregates;

namespace Bistrotic.MexicanDigitalInvoice.Domain.States
{
    public interface IUblInvoiceState
    {
        Invoice Invoice { get; set; }

        void Apply(IEnumerable<object> events);
    }
}