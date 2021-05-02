namespace Bistrotic.MexicanDigitalInvoice.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.MexicanDigitalInvoice.Aggregates;
    using Bistrotic.MexicanDigitalInvoice.Domain.States;
    using Bistrotic.MexicanDigitalInvoice.Events;

    public class MexicanDigitalInvoice
    {
        private readonly string _id;
        private readonly IMexicanDigitalInvoiceState _state;

        public MexicanDigitalInvoice(string id, IMexicanDigitalInvoiceState state)
        {
            _id = id;
            _state = state;
        }

        public Task<IEnumerable<object>> Submit(
            Voucher invoice)
        {
            List<object> events = new();
            events.Add(new MexicanDigitalInvoiceSubmitted
            {
                Invoice = invoice
            });
            _state.Apply(events);
            return Task.FromResult<IEnumerable<object>>(events);
        }
    }
}