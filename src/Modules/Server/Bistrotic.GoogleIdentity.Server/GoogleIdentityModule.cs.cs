namespace Bistrotic.GoogleIdentity
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class GoogleIdentityModule : ServerModule
    {
        private readonly GoogleIdentitySettings _settings;

        public GoogleIdentityModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode) : base(moduleDefinition, configuration, environment, clientMode)
        {
            _settings = Configuration.GetSettings<GoogleIdentitySettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSettings<GoogleIdentitySettings>(Configuration);

            if (!string.IsNullOrWhiteSpace(_settings.ClientId))
            {
                services
                    .AddAuthentication(o =>
                        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme
                    )
                    .AddGoogle(o =>
                    {
                        o.ClientId = _settings.ClientId;
                        o.ClientSecret = _settings.ClientSecret;
                    });
            }
        }
    }
}