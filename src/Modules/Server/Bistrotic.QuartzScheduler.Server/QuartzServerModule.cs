namespace Bistrotic.QuartzScheduler
{
    using Bistrotic.Application.Messages;
    using Bistrotic.Infrastructure;
    using Bistrotic.Infrastructure.Modules.Definitions;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.QuartzScheduler.Application.Queries;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Quartz;

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
            services.AddQuartz(q =>
            {
                // base quartz scheduler, job and trigger configuration handy when part of cluster
                // or you want to otherwise identify multiple schedulers
                q.SchedulerId = nameof(Bistrotic);

                // Scoped service support like EF Core DbContext
                q.UseMicrosoftDependencyInjectionScopedJobFactory(p =>
                {
                    p.CreateScope = true;
                    p.AllowDefaultConstructor = true;
                });

                // these are the defaults
                q.UseSimpleTypeLoader();
                q.UseInMemoryStore();
                q.UseDefaultThreadPool(tp =>
                {
                    tp.MaxConcurrency = 10;
                });
            });

            // ASP.NET Core hosting
            services.AddQuartzServer(options =>
            {
                // when shutting down we want jobs to complete gracefully
                options.WaitForJobsToComplete = true;
            });
        }
    }
}