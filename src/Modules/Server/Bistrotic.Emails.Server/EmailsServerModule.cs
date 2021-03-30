namespace Bistrotic.Emails
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Emails.Application.Queries;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

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
    }
}