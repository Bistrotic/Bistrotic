namespace Bistrotic.MudBlazorTheme
{
    using System;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.MudBlazorTheme.Projections.Handlers;
    using Bistrotic.MudBlazorTheme.Queries;
    using Bistrotic.MudBlazorTheme.Settings;
using Bistrotic.MudBlazorTheme.ViewModels;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class MudBlazorThemeServerModule : ServerModule
    {
        private MudBlazorThemeSettings? _settings;

        public MudBlazorThemeServerModule(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public MudBlazorThemeSettings Settings => _settings ??= Configuration.GetSettings<MudBlazorThemeSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            _ = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            messageBuilder.AddAssemblyMessages(typeof(MudBlazorThemeSettings).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.ConfigureSettings<MudBlazorThemeSettings>(Configuration);
            services.AddTransient<IQueryHandler<GetMudBlazorThemeSetup, MudBlazorThemeSetup>, GetMudBlazorThemeSetupHandler>();
            services.AddMudBlazorRenderers();
        }
    }
}