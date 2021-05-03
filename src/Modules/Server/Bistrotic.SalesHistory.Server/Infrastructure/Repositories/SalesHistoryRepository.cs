#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Bistrotic.SalesHistory.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.SalesHistory.Common.Application.Services;
    using Bistrotic.SalesHistory.Common.Application.States;

    using Microsoft.Extensions.Logging;

    public class SalesHistoryRepository : ISalesHistoryRepository
    {
        private readonly SalesHistoryDbContext _context;
        private readonly ILogger<SalesHistoryDbContext> _logger;

        public SalesHistoryRepository(SalesHistoryDbContext context, ILogger<SalesHistoryDbContext> logger)
        {
            _logger = logger;
            _context = context;
        }

        IQueryable<SalesHistoryState> ISalesHistoryRepository.Sales => _context.SalesHistory;

#pragma warning disable AsyncFixer01 // Unnecessary async/await usage

        public async Task AddSales(IEnumerable<SalesHistoryState> sales, CancellationToken cancellationToken = default)
        {
            _context.SalesHistory.AddRange(sales);
            await _context.SaveChangesAsync(cancellationToken);
        }

#pragma warning restore AsyncFixer01 // Unnecessary async/await usage
    }
}