namespace Bistrotic.UblDocuments.Infrastructure.Ef.Entities
{
    using Bistrotic.UblDocuments.Types.Entities;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DocumentReferenceTypeConfiguration : IEntityTypeConfiguration<DocumentReference>
    {
        public void Configure(EntityTypeBuilder<DocumentReference> builder)
        {
            builder.OwnsOne(i => i.ValidityPeriod);
            builder.OwnsOne(i => i.Attachment,
                a => a.OwnsOne(p => p.ExternalReference));
        }
    }
}