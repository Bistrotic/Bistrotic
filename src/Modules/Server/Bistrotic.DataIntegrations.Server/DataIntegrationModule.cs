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

    public sealed class DataIntegrationModule : ServerModule
    {
        private readonly DataIntegrationSettings _settings;

        public DataIntegrationModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
            _settings = configuration.GetSettings<DataIntegrationSettings>();
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