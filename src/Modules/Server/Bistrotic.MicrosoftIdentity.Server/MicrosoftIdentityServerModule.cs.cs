namespace Bistrotic.MicrosoftIdentity
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Identity.Web;

    public class MicrosoftIdentityServerModule : ServerModule
    {
        private readonly MicrosoftIdentitySettings _settings;

        public MicrosoftIdentityServerModule(IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(configuration, environment, clientMode)
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