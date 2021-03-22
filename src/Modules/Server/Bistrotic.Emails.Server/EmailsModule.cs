namespace Bistrotic.Emails
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Emails.Application.Queries;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Helpers;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class EmailsModule : ServerModule
    {
        private readonly EmailsSettings _settings;

        public EmailsModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
            _settings = configuration.GetSettings<EmailsSettings>();
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetEmailDetails).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}