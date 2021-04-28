namespace Bistrotic.UblDocuments.Domain
{
    using Bistrotic.UblDocuments.Domain.States;
    using Bistrotic.UblDocuments.Events;
    using Bistrotic.UblDocuments.Types.Aggregates;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UblInvoice
    {
        private readonly string _id;
        private readonly IUblInvoiceState _state;

        public UblInvoice(string id, IUblInvoiceState state)
        {
            _id = id;
            _state = state;
        }

        public Task<IEnumerable<object>> Submit(
            Invoice invoice)
        {
            List<object> events = new();
            events.Add(new UblInvoiceSubmitted
            {
                Invoice = invoice
            });
            _state.Apply(events);
            return Task.FromResult<IEnumerable<object>>(events);
        }
    }
}