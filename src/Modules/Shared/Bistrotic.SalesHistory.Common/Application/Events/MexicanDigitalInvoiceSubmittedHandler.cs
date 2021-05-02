namespace Bistrotic.SalesHistory.Application.Events
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.MexicanDigitalInvoice.Events;
    using Bistrotic.SalesHistory.Application.Exceptions;
    using Bistrotic.SalesHistory.Common.Application.Services;
    using Bistrotic.SalesHistory.Common.Application.States;

    using Microsoft.Extensions.Logging;

    [EventHandler(Event = typeof(MexicanDigitalInvoiceSubmitted))]
    public class MexicanDigitalInvoiceSubmittedHandler : IEventHandler<MexicanDigitalInvoiceSubmitted>
    {
        private readonly ILogger<MexicanDigitalInvoiceSubmittedHandler> _logger;
        private readonly ISalesHistoryRepository _repository;

        public MexicanDigitalInvoiceSubmittedHandler(ISalesHistoryRepository repository, ILogger<MexicanDigitalInvoiceSubmittedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
           => Handle(new Envelope<MexicanDigitalInvoiceSubmitted>(envelope), cancellationToken);

        public async Task Handle(Envelope<MexicanDigitalInvoiceSubmitted> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                var invoice = envelope.Message.Invoice.Addendum?.Invoice;
                if (invoice == null)
                {
                    throw new MexicanDigitalInvoiceDeserializationException($"Missing invoice document in Xml file. MessageId='{envelope.MessageId}'.");
                }
                int i = 0;
                await _repository.AddSales(
                invoice.InvoiceLines
                    .Select(p => new SalesHistoryState()
                    {
                        CompanyId = invoice.Identification?.IssuerCode ?? string.Empty,
                        CompanyName = invoice.Identification?.IssuerName ?? string.Empty,
                        CustomerId = invoice.Customer?.Code ?? string.Empty,
                        CustomerName = invoice.Customer?.Name ?? string.Empty,
                        Currency = envelope.Message.Invoice.Currency ?? string.Empty,
                        InvoiceDate = envelope.Message.Invoice.DocumentDate ?? DateTime.MinValue,
                        InvoiceId = envelope.Message.Invoice.InvoiceId ?? string.Empty,
                        UUID = invoice.Identification?.IssuerCode + "-" + envelope.Message.Invoice.InvoiceId,
                        SalesId = string.Empty,
                        LineId = Convert.ToString(++i, CultureInfo.InvariantCulture),
                        ItemId = p.Description.Split(' ', 2).FirstOrDefault() ?? string.Empty,
                        ItemName = p.Description.Split(' ', 2).Skip(1).FirstOrDefault() ?? string.Empty,
                        Quantity = p.Quantity,
                        TotalAmount = p.LineAmount
                    }), cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Mexican digital invoice submitted event handler error : {e.Message}.\nMessageId={envelope.MessageId}; InvoiceId={envelope.Message.Invoice.InvoiceId}.");
                throw;
            }
        }
    }
}