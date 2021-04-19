namespace Bistrotic.UblInvoices.Application
{
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.UblDocuments.Types.Entities;

    public interface IInvoiceLineRepository
    {
        public IQueryable<InvoiceLine> InvoiceLines { get; }
        public Task Add(InvoiceLine invoiceLine);
        public Task Save();
    }
}
