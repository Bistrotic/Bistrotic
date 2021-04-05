using System.IO;

using Bistrotic.Infrastructure.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bistrotic.SalesHistory.Repositories
{
    public class SalesHistoryContextFactory : IDesignTimeDbContextFactory<SalesHistoryDbContext>
    {
        public SalesHistoryDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var settings = configuration.GetSettings<SalesHistorySettings>();
            var dbContextBuilder = new DbContextOptionsBuilder<SalesHistoryDbContext>();

            dbContextBuilder.UseSqlServer(settings.ConnectionString);

            return new SalesHistoryDbContext(dbContextBuilder.Options);
        }
    }
}