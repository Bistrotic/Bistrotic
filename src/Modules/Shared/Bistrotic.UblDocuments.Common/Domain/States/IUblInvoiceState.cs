using Bistrotic.UblDocuments.Types.Aggregates;

using System.Collections.Generic;

namespace Bistrotic.UblDocuments.Domain.States
{
    public interface IUblInvoiceState
    {
        Invoice Invoice { get; set; }

        void Apply(IEnumerable<object> events);
    }
}