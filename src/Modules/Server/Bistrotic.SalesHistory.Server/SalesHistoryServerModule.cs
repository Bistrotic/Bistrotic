namespace Bistrotic.Roles
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.SalesHistory.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class SalesHistoryServerModule : ServerModule
    {
        private readonly SalesHistorySettings _settings;

        public SalesHistoryServerModule(IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(configuration, environment, clientMode)
        {
            _settings = configuration.GetSettings<SalesHistorySettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetSalesTransactionDetails).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}