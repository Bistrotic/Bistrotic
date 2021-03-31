namespace Bistrotic.DataIntegrations
{
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Application.Queries;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.QuartzScheduler.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class DataIntegrationsServerModule : ServerModule
    {
        private DataIntegrationsSettings? _settings;

        public DataIntegrationsServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }

        public DataIntegrationsSettings Settings
                            => _settings ??= Configuration.GetSettings<DataIntegrationsSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetDataIntegrationDetails).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddQuartzScheduler(nameof(DataIntegration));
        }
    }
}