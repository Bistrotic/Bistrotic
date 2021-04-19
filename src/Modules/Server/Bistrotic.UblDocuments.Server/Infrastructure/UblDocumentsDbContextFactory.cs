using System.IO;

using Bistrotic.Infrastructure.Helpers;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Bistrotic.UblDocuments.Infrastructure
{
    public class UblDocumentsDbContextFactory : IDesignTimeDbContextFactory<UblDocumentsDbContext>
    {
        public UblDocumentsDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            var settings = configuration.GetSettings<UblDocumentsSettings>();
            var dbContextBuilder = new DbContextOptionsBuilder<UblDocumentsDbContext>();

            dbContextBuilder.UseSqlServer(settings.ConnectionString);

            return new UblDocumentsDbContext(dbContextBuilder.Options);
        }
    }
}