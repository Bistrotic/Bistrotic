namespace Bistrotic.MicrosoftIdentity
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Identity.Web;
    using Bistrotic.Infrastructure.Helpers;
    using Microsoft.AspNetCore.Identity;

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

            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(Configuration.GetSection($"{nameof(MicrosoftIdentitySettings)}:{nameof(MicrosoftIdentitySettings.AzureAd)}"));
            /*
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                          .AddMicrosoftIdentityWebApp(Configuration.GetSection($"{nameof(MicrosoftIdentitySettings)}:{nameof(MicrosoftIdentitySettings.AzureAd)}"))
                              .EnableTokenAcquisitionToCallDownstreamApi()
                                  .AddMicrosoftGraph(Configuration.GetSection($"{nameof(MicrosoftIdentitySettings)}:{nameof(MicrosoftIdentitySettings.MicrosoftGraph)}"))
                                  .AddInMemoryTokenCaches();

            services.AddAuthentication()
                      .AddMicrosoftIdentityWebApi(Configuration.GetSection($"{nameof(MicrosoftIdentitySettings)}:{nameof(MicrosoftIdentitySettings.AzureAd)}"),
                                                  JwtBearerDefaults.AuthenticationScheme)
                      .EnableTokenAcquisitionToCallDownstreamApi();
            */
        }
    }
}
