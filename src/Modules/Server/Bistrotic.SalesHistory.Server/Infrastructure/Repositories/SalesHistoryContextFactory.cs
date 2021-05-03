namespace Bistrotic.SalesHistory.Infrastructure.Repositories
{
    using System.IO;

    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.SalesHistory.Settings;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

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