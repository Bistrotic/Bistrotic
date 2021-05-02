namespace Bistrotic.MexicanDigitalInvoice.Domain.States
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.MexicanDigitalInvoice.Events;
    using Bistrotic.MexicanDigitalInvoice.Types.Aggregates;

    public sealed class UblInvoiceState : IUblInvoiceState
    {
        public Invoice Invoice { get; set; } = new();

        public void Apply(IEnumerable<object> events)
        {
            foreach (var @event in events)
            {
                switch (@event)
                {
                    case UblInvoiceSubmitted submitted:
                        Apply(submitted);
                        break;

                    default:
                        throw new NotSupportedException($"Event type '{@event.GetType().Name} is not supported by '{nameof(UblInvoiceState)}''");
                }
            }
        }

        private void Apply(UblInvoiceSubmitted submitted)
        {
            Invoice = submitted.Invoice;
        }
    }
}