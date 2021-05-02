namespace Bistrotic.MexicanDigitalInvoice.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.MexicanDigitalInvoice.Domain.States;
    using Bistrotic.MexicanDigitalInvoice.Events;
    using Bistrotic.MexicanDigitalInvoice.Types.Aggregates;

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