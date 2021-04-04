namespace Bistrotic.Emails
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Application.Queries;
    using Bistrotic.Emails.Domain.States;
    using Bistrotic.Emails.Repositories;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<EmailsDbContext>(options => options.UseSqlServer(Settings.ConnectionString));
            services.AddTransient<IRepository<IEmailState>>(p => p.GetRequiredService<EmailsDbContext>());
            services.AddHostedService<ReceiveAllEmailsJob>();
            services.AddHostedService<ReceiveUnreadEmailsJob>();
        }
    }
}