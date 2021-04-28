namespace Bistrotic.UblDocuments.Infrastructure.Ef.Entities
{
    using Bistrotic.UblDocuments.Types.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvoiceLineTypeConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.OwnsOne(i => i.OrderLineReference, o => o.WithOwner());
            builder.OwnsOne(i => i.InvoicePeriod);
            builder.OwnsOne(i => i.Price);
        }
    }
}