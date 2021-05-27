namespace Bistrotic.FastTheme
{
    using System;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.FastTheme.Projections.Handlers;
    using Bistrotic.FastTheme.Queries;
    using Bistrotic.FastTheme.Settings;
using Bistrotic.FastTheme.ViewModels;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class FastThemeServerModule : ServerModule
    {
        private FastThemeSettings? _settings;

        public FastThemeServerModule(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public FastThemeSettings Settings => _settings ??= Configuration.GetSettings<FastThemeSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            _ = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            messageBuilder.AddAssemblyMessages(typeof(FastThemeSettings).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.ConfigureSettings<FastThemeSettings>(Configuration);
            services.AddTransient<IQueryHandler<GetFastThemeSetup, FastThemeSetup>, GetFastThemeSetupHandler>();
        }
    }
}