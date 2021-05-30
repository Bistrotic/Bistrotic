namespace Bistrotic.ApplicationLayer
{
    using System;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.ApplicationLayer.Projections.Handlers;
    using Bistrotic.ApplicationLayer.Queries;
    using Bistrotic.ApplicationLayer.Settings;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class ApplicationLayerServerModule : ServerModule
    {
        private ApplicationLayerSettings? _settings;

        public ApplicationLayerServerModule(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public ApplicationLayerSettings Settings => _settings ??= Configuration.GetSettings<ApplicationLayerSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            _ = messageBuilder ?? throw new ArgumentNullException(nameof(messageBuilder));
            messageBuilder.AddAssemblyMessages(typeof(ApplicationLayerSettings).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.ConfigureSettings<ApplicationLayerSettings>(Configuration);
            services.AddTransient<IQueryHandler<GetApplicationName, string>, GetApplicationNameHandler>();
        }
    }
}