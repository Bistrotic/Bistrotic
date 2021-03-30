#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using Microsoft.EntityFrameworkCore;

    public sealed class EventStoreDbContext : DbContext
    {
        public EventStoreDbContext(DbContextOptions<EventStoreDbContext> options)
               : base(options)
        {
        }

        public DbSet<EventStreamItem> EventStream { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventStreamItem>(b =>
            {
                b.HasKey(p => new { p.StreamIdHash, p.Version, p.StreamId });
                b.Property(p => p.SystemUtcDateTime).HasDefaultValueSql("getdate()");
            });
        }
    }
}