#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Bistrotic.SalesHistory.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.SalesHistory.Common.Application.Services;
    using Bistrotic.SalesHistory.Common.Application.States;

    using Microsoft.EntityFrameworkCore;

    public class SalesHistoryDbContext : DbContext, ISalesHistoryRepository
    {
        public SalesHistoryDbContext(DbContextOptions<SalesHistoryDbContext> options)
               : base(options)
        {
        }

        public DbSet<SalesHistoryState> SalesHistory { get; set; }
        IQueryable<SalesHistoryState> ISalesHistoryRepository.Sales => SalesHistory;

        public Task AddSales(IEnumerable<SalesHistoryState> sales, CancellationToken cancellationToken = default)
        {
            SalesHistory.AddRange(sales);
            return SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var builder = modelBuilder.Entity<SalesHistoryState>();
            builder.Property<int>("Id")
               .HasColumnType("int")
               .ValueGeneratedOnAdd();
            builder.HasKey("Id");
        }
    }
}