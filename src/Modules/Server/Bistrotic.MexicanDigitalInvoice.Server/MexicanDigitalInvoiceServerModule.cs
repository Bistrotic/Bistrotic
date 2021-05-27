namespace Bistrotic.MexicanDigitalInvoice
{
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.MexicanDigitalInvoice.Application.Events;
    using Bistrotic.MexicanDigitalInvoice.Domain.States;
    using Bistrotic.MexicanDigitalInvoice.Events;
    using Bistrotic.MexicanDigitalInvoice.Infrastructure;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class MexicanDigitalInvoiceServerModule : ServerModule
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly MexicanDigitalInvoiceSettings _settings;
#pragma warning restore IDE0052 // Remove unread private members

        public MexicanDigitalInvoiceServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
            _settings = configuration.GetSettings<MexicanDigitalInvoiceSettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(MexicanDigitalInvoiceSubmitted).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEventHandler<DataIntegrationSubmitted>, DataIntegrationSubmittedHandler>();
            services.AddTransient<IRepository<IMexicanDigitalInvoiceState>, EfRepository<IMexicanDigitalInvoiceState, MexicanDigitalInvoiceState>>();
        }
    }
}