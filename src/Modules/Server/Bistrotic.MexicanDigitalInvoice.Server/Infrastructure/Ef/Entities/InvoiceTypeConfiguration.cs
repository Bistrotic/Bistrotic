namespace Bistrotic.UblDocuments.Infrastructure.Ef.Entities
{
    using Bistrotic.UblDocuments.Types.Aggregates;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvoiceTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.OwnsOne(i => i.OrderReference);
            builder.OwnsOne(i => i.InvoicePeriod);
            builder.OwnsOne(i => i.LegalMonetaryTotal);
            builder.OwnsOne(i => i.DeliveryTerms);
        }
    }
}