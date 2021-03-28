namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class EfCoreHelper
    {
        public static IServiceCollection AddSqlServerEventStore(this IServiceCollection services, string connectionString)
        =>
            services.AddDbContext<EventStoreDbContext>(o => o.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly(typeof(EventStoreDbContext).Assembly.FullName))
            );
    }
}