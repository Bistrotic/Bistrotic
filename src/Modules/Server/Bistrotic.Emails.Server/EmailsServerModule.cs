namespace Bistrotic.Emails
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Application.CommandHandlers;
    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Emails.Application.EventHandlers;
    using Bistrotic.Emails.Application.Queries;
    using Bistrotic.Emails.Application.Services;
    using Bistrotic.Emails.Application.Settings;
    using Bistrotic.Emails.Contracts.Events;
    using Bistrotic.Emails.Domain.States;
    using Bistrotic.Infrastructure.EfCore.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class EmailsServerModule : ServerModule
    {
        private EmailsSettings? _settings;

        public EmailsServerModule(IConfiguration configuration, IWebHostEnvironment environment) : base(configuration, environment)
        {
        }

        public EmailsSettings Settings => _settings ??= Configuration.GetSettings<EmailsSettings>();

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetEmailDetails).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.ConfigureSettings<EmailsSettings>(Configuration);
            services.AddTransient<IRepository<IEmailState>, EfRepository<IEmailState, EmailState>>();
            services.AddHostedService<ReceiveAllEmailsJob>();
            services.AddHostedService<ReceiveUnreadEmailsJob>();
            services.AddTransient<ICommandHandler<ReceiveEmail>, ReceiveEmailHandler>();
            services.AddTransient<ICommandHandler<ReceiveAllEmails>, ReceiveAllEmailsHandler>();
            services.AddTransient<ICommandHandler<ReceiveUnreadEmails>, ReceiveUnreadEmailsHandler>();
            services.AddTransient<IEventHandler<EmailReceived>, EmailReceivedHandler>();

            // TODO move to graph module
            services.AddTransient<IMailboxService, GraphMailboxService>();
        }
    }
}