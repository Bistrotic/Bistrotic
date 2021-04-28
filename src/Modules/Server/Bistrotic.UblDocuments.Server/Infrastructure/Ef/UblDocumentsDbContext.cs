#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace Bistrotic.UblDocuments.Infrastructure.Ef
{
    using Bistrotic.UblDocuments.Application;
    using Bistrotic.UblDocuments.Infrastructure.Ef.Entities;
    using Bistrotic.UblDocuments.Types.Aggregates;
    using Bistrotic.UblDocuments.Types.Entities;

    using Microsoft.EntityFrameworkCore;

    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class UblDocumentsDbContext :
        DbContext,
        IRepository
    {
        public UblDocumentsDbContext(DbContextOptions<UblDocumentsDbContext> options)
                     : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DocumentReference> DocumentReferences { get; set; }
        public DbSet<BillingReference> BillingReferences { get; set; }
        public DbSet<BillingReferenceLine> BillingReferenceLines { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Integration> Integrations { get; set; }
        public DbSet<Item> Items { get; set; }

        public Task Save(CancellationToken cancellationToken = default)
            => SaveChangesAsync(cancellationToken);

        public IQueryable<T> GetSet<T>() where T : class => Set<T>();

        void IRepository.Add<T>(T record) => Add(record);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IntegrationTypeConfiguration).Assembly);
        }
    }
}