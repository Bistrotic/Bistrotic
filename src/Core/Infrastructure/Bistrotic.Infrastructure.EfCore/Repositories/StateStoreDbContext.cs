#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using Microsoft.EntityFrameworkCore;

    public class StateStoreDbContext
        : DbContext
    {
        public StateStoreDbContext(DbContextOptions<StateStoreDbContext> options)
               : base(options)
        {
        }

        public DbSet<State> States { get; set; }
        public DbSet<OutboxMessage> Outbox { get; set; }
        public DbSet<EventStreamItem> EventStore { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(b =>
            {
                b.HasKey(p => new { p.IdHash, p.Id });
                b.Property(p => p.Version).IsConcurrencyToken();
            });
        }
    }
}