namespace Bistrotic.MicrosoftIdentity
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Identity.Web;
    using Microsoft.Identity.Web.UI;

    public class MicrosoftIdentityModule : ServerModule
    {
        private readonly MicrosoftIdentitySettings _settings;

        public MicrosoftIdentityModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode) : base(moduleDefinition, configuration, environment, clientMode)
        {
            _settings = Configuration.GetSettings<MicrosoftIdentitySettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSettings<MicrosoftIdentitySettings>(Configuration);

            if (!string.IsNullOrWhiteSpace(_settings.AzureAd.ClientId))
            {
                services
                    .AddMicrosoftIdentityWebAppAuthentication(
                            Configuration,
                            nameof(MicrosoftIdentitySettings) + ":" + nameof(MicrosoftIdentitySettings.AzureAd));
            }
        }
    }
}