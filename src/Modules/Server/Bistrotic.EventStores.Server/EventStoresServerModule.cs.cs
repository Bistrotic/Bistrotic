namespace Bistrotic.EventStores
{
    using Bistrotic.Application.Messages;
    using Bistrotic.EventStores.Exceptions;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class EventStoresServerModule : ServerModule
    {
        private readonly EventStoresSettings _settings;

        public EventStoresServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = Configuration.GetSettings<EventStoresSettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSettings<EventStoresSettings>(Configuration);

            if (string.IsNullOrWhiteSpace(_settings.ConnectionString))
            {
                throw new EventStoreSettingsException(nameof(EventStoresSettings.ConnectionString), "The database connection string is not defined.");
            }
            services.AddSqlServerEventStore(_settings.ConnectionString);

            if (Environment.IsDevelopment())
            {
                services.AddDatabaseDeveloperPageExceptionFilter();
            }
        }
    }
}