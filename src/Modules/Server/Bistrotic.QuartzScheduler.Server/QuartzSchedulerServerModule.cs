namespace Bistrotic.QuartzScheduler
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.Infrastucture.QuartzScheduler.Helpers;
    using Bistrotic.QuartzScheduler.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class QuartzSchedulerServerModule : ServerModule
    {
        public QuartzSchedulerServerModule(IConfiguration configuration, IWebHostEnvironment environment)
            : base(configuration, environment)
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