namespace Bistrotic.EventStores
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.EventStores.Exceptions;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class EventStoresServerModule : ServerModule
    {
        private readonly EventStoresSettings _settings;

        public EventStoresServerModule(IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(configuration, environment, clientMode)
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

        public override async Task OnStartup(IServiceProvider services)
        {
            await base.OnStartup(services);
            using var scope = services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<EventStoreDbContext>();
                await context.Database.EnsureCreatedAsync();
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<EventStoresServerModule>>();
                logger.LogError(ex, $"An error occurred while creating the '{nameof(EventStoreDbContext)}' database.");
            }
        }
    }
}