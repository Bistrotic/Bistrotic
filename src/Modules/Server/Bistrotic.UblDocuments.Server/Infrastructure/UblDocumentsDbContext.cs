#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Bistrotic.UblDocuments.Infrastructure
{
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.UblDocuments.Types.Aggregates;
    using Bistrotic.UblDocuments.Types.Entities;
    using Bistrotic.UblInvoices.Application;

    using Microsoft.EntityFrameworkCore;

    public class UblDocumentsDbContext :
        DbContext,
        ICountryRepository,
        IUblIntegrationRepository,
        IInvoiceRepository,
        IInvoiceLineRepository
    {
        public UblDocumentsDbContext(DbContextOptions<UblDocumentsDbContext> options)
                     : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<UblIntegration> Integrations { get; set; }

        public Task Add(Country country)
        {
            Countries.Add(country);
            return Task.CompletedTask;
        }
        public Task Add(Invoice invoice)
        {
            Invoices.Add(invoice);
            return Task.CompletedTask;
        }
        public Task Add(InvoiceLine invoiceLine)
        {
            InvoiceLines.Add(invoiceLine);
            return Task.CompletedTask;
        }
        public Task Add(UblIntegration integration)
        {
            Integrations.Add(integration);
            return Task.CompletedTask;
        }

        public Task Save() => SaveChangesAsync();

        IQueryable<UblIntegration> IUblIntegrationRepository.Integrations => Integrations;
        IQueryable<Country> ICountryRepository.Countries => Countries;
        IQueryable<Invoice> IInvoiceRepository.Invoices => Invoices;
        IQueryable<InvoiceLine> IInvoiceLineRepository.InvoiceLines => InvoiceLines;
    }
}