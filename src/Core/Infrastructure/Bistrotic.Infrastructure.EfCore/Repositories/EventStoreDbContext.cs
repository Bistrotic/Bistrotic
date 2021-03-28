#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using Microsoft.EntityFrameworkCore;

    public class EventStoreDbContext : DbContext
    {
        public DbSet<EventStreamItem> EventStream { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventStreamItem>(b =>
            {
                b.HasIndex(p => p.Hash);
                b.HasIndex(p => p.PartitionId);
                b.Property(p => p.SystemUtcDateTime).HasDefaultValueSql("getdate()");
            });
        }
    }
}