namespace Bistrotic.SalesHistory.Application.Events
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.SalesHistory.Common.Application.Services;
    using Bistrotic.SalesHistory.Common.Application.States;
    using Bistrotic.UblDocuments.Events;

    using Microsoft.Extensions.Logging;

    [EventHandler(Event = typeof(UblInvoiceSubmitted))]
    public class UblInvoiceSubmittedHandler : IEventHandler<UblInvoiceSubmitted>
    {
        private readonly ILogger<UblInvoiceSubmittedHandler> _logger;
        private readonly ISalesHistoryRepository _repository;

        public UblInvoiceSubmittedHandler(ISalesHistoryRepository repository, ILogger<UblInvoiceSubmittedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
           => Handle(new Envelope<UblInvoiceSubmitted>(envelope), cancellationToken);

        public async Task Handle(Envelope<UblInvoiceSubmitted> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                var invoice = envelope.Message.Invoice;
                await _repository.AddSales(
                invoice.InvoiceLine
                    .Select(p => new SalesHistoryState()
                    {
                        CompanyId = invoice.AccountingSupplierParty.Party?.PartyIdentification.FirstOrDefault()?.ID ?? string.Empty,
                        CompanyName = invoice.AccountingSupplierParty.Party?.PartyName.Name ?? string.Empty,
                        CustomerId = invoice.AccountingCustomerParty.Party?.PartyIdentification.FirstOrDefault()?.ID ?? string.Empty,
                        CustomerName = invoice.AccountingCustomerParty.Party?.PartyName.Name ?? string.Empty,
                        Currency = invoice.DocumentCurrencyCode ?? string.Empty,
                        InvoiceDate = invoice.IssueDateTime ?? DateTimeOffset.MinValue,
                        InvoiceId = invoice.ID ?? string.Empty,
                        UUID = invoice.UUID ?? new AutoIdentifier().Value,
                        SalesId = string.Empty,
                        LineId = p.ID,
                        ItemId = p.Item.SellersItemIdentification?.ID ?? string.Empty,
                        ItemName = p.Item.Description,
                        Quantity = p.InvoicedQuantity,
                        TotalAmount = p.LineExtensionAmount
                    }), cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"UBL Invoice submitted event handler error : {e.Message}.\nMessageId={envelope.MessageId}; InvoiceId={envelope.Message.Invoice.ID}.");
                throw;
            }
        }
    }
}