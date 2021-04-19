﻿namespace Bistrotic.UblDocuments
{
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.UblDocuments.Application.Events;
    using Bistrotic.UblDocuments.Events;
    using Bistrotic.UblDocuments.Infrastructure;
    using Bistrotic.UblInvoices.Application;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class UblDocumentsServerModule : ServerModule
    {
        private readonly UblDocumentsSettings _settings;

        public UblDocumentsServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = configuration.GetSettings<UblDocumentsSettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(UblInvoiceCreated).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UblDocumentsDbContext>(o => o.UseSqlServer(_settings.ConnectionString));
            services.AddTransient<IEventHandler<DataIntegrationSubmitted>, DataIntegrationSubmittedHandler>();
            services.AddTransient<IUblIntegrationRepository, UblDocumentsDbContext>();
            services.AddTransient<IInvoiceRepository, UblDocumentsDbContext>();
        }
    }
}