﻿namespace Bistrotic.DataIntegrations
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.DataIntegrations.Application.CommandHandlers;
    using Bistrotic.DataIntegrations.Application.Commands;
    using Bistrotic.DataIntegrations.Domain.States;
    using Bistrotic.Emails.Contracts.Events;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class DataIntegrationsServerModule : ServerModule
    {
        private DataIntegrationsSettings? _settings;

        public DataIntegrationsServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
        {
        }

        public DataIntegrationsSettings Settings
                            => _settings ??= Configuration.GetSettings<DataIntegrationsSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(SubmitDataIntegration).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.ConfigureSettings<DataIntegrationsSettings>(Configuration);
            services.AddTransient<IRepository<IDataIntegrationState>, StateStoreRepository<IDataIntegrationState, DataIntegrationState>>();
            services.AddTransient<IEventHandler<EmailReceived>, EmailReceivedHandler>();
            services.AddTransient<ICommandHandler<SubmitDataIntegration>, SubmitDataIntegrationHandler>();
        }
    }
}