namespace Bistrotic.UblDocuments
{
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.UblDocuments.Application.Events;
    using Bistrotic.UblDocuments.Domain.States;
    using Bistrotic.UblDocuments.Events;
    using Bistrotic.UblDocuments.Infrastructure;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class UblDocumentsServerModule : ServerModule
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly UblDocumentsSettings _settings;
#pragma warning restore IDE0052 // Remove unread private members

        public UblDocumentsServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = configuration.GetSettings<UblDocumentsSettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(UblInvoiceSubmitted).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<UblDocumentsDbContext>(o => o.UseSqlServer(_settings.ConnectionString));
            services.AddTransient<IEventHandler<DataIntegrationSubmitted>, DataIntegrationSubmittedHandler>();
            services.AddTransient<IRepository<IUblInvoiceState>, EfRepository<IUblInvoiceState, UblInvoiceState>>();
        }
    }
}