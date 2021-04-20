namespace Bistrotic.UblDocuments.Infrastructure.Ef.Entities
{
    using Bistrotic.UblDocuments.Application;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class IntegrationTypeConfiguration : IEntityTypeConfiguration<Integration>
    {
        public void Configure(EntityTypeBuilder<Integration> builder)
        {
            builder.HasIndex(p => p.MessageId).IsUnique();
            builder.HasIndex(p => p.IntegrationDate);
            builder.HasIndex(p => p.ReceivedDate);
        }
    }
}