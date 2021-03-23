namespace Bistrotic.QuartzScheduler
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Infrastucture.QuartzScheduler.Helpers;
    using Bistrotic.QuartzScheduler.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class QuartzServerModule : ServerModule
    {
        public QuartzServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration, IWebHostEnvironment environment, ClientMode clientMode)
            : base(moduleDefinition, configuration, environment, clientMode)
        {
        }

        public override void ConfigureMessages(IMessageFactoryBuilder messageBuilder)
        {
            messageBuilder.AddAssemblyMessages(typeof(GetJobSummaryList).Assembly);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddQuartzScheduler(nameof(Bistrotic));
        }
    }
}