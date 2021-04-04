﻿namespace Bistrotic.EventStores
{
    using Bistrotic.EventStores.Exceptions;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class EventStoresServerModule : ServerModule
    {
        private EventStoresSettings? _settings;

        public EventStoresServerModule(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public EventStoresSettings Settings => _settings ??= Configuration.GetSettings<EventStoresSettings>();

        public override void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSettings<EventStoresSettings>(Configuration);

            if (string.IsNullOrWhiteSpace(Settings.ConnectionString))
            {
                throw new EventStoreSettingsException(nameof(EventStoresSettings.ConnectionString), "The database connection string is not defined.");
            }
        }
    }
}