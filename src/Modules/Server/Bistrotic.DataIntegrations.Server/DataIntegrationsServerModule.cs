namespace Bistrotic.DataIntegrations
{
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Application.Queries;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Infrastucture.QuartzScheduler.Helpers;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class DataIntegrationsServerModule : ServerModule
    {
        private readonly DataIntegrationsSettings _settings;

        public DataIntegrationsServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = configuration.GetSettings<DataIntegrationsSettings>();
        }

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