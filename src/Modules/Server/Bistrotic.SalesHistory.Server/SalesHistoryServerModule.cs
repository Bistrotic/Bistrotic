namespace Bistrotic.SalesHistory
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.SalesHistory.Contracts.Queries;
    using Bistrotic.SalesHistory.Repositories;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class SalesHistoryServerModule : ServerModule
    {
        private readonly SalesHistorySettings _settings;

        public SalesHistoryServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = configuration.GetSettings<SalesHistorySettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetSalesHistoryCount).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SalesHistoryDbContext>(o => o.UseSqlServer(_settings.ConnectionString));
        }
    }
}