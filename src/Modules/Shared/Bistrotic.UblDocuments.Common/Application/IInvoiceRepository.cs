namespace Bistrotic.UblInvoices.Application
{
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.UblDocuments.Types.Aggregates;

    public interface IInvoiceRepository
    {
        public IQueryable<Invoice> Invoices { get; }
        public Task Add(Invoice invoice);
        public Task Save();
    }
}
