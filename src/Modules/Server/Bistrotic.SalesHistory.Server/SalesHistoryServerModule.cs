namespace Bistrotic.SalesHistory
{
    using System;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.MexicanDigitalInvoice.Events;
    using Bistrotic.SalesHistory.Application.Events;
    using Bistrotic.SalesHistory.Common.Application.Services;
    using Bistrotic.SalesHistory.Contracts.Queries;
    using Bistrotic.SalesHistory.Infrastructure.Repositories;
    using Bistrotic.SalesHistory.Settings;
    using Bistrotic.UblDocuments.Events;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class SalesHistoryServerModule : ServerModule
    {
        private readonly SalesHistorySettings _settings;

        public SalesHistoryServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = configuration.GetSettings<SalesHistorySettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            if (messageBuilder == null)
            {
                throw new ArgumentNullException(nameof(messageBuilder));
            }
            messageBuilder.AddAssemblyMessages(typeof(GetSalesHistoryCount).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            if (!string.IsNullOrWhiteSpace(_settings.ConnectionString))
            {
                services.AddDbContext<SalesHistoryDbContext>(o => o.UseSqlServer(_settings.ConnectionString), ServiceLifetime.Transient);
                services.AddTransient<IEventHandler<UblInvoiceSubmitted>, UblInvoiceSubmittedHandler>();
                services.AddTransient<IEventHandler<MexicanDigitalInvoiceSubmitted>, MexicanDigitalInvoiceSubmittedHandler>();
                services.AddTransient<ISalesHistoryRepository, SalesHistoryRepository>();
            }
            else
            {
                Console.WriteLine($"Info: Database settings ({nameof(SalesHistorySettings) + ":" + nameof(SalesHistorySettings.ConnectionString)}) not set for sales history module.");
            }
        }
    }
}