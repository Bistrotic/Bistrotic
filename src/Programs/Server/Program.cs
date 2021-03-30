namespace Bistrotic.Server
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.DataIntegrations;
    using Bistrotic.Emails;
    using Bistrotic.EventStores;
    using Bistrotic.GoogleIdentity;
    using Bistrotic.Infrastructure.WebServer;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.OpenIdDict;
    using Bistrotic.Roles;
    using Bistrotic.Units;
    using Bistrotic.Users;
    using Bistrotic.WorkItems;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program : ServerProgram
    {
        public Program(string[] args) : base(args)
        {
        }

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => new Program(args).HostBuilder;

        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public override void Configure(IApplicationBuilder app, WebHostBuilderContext context)
        {
            base.Configure(app, context);
            if (context.HostingEnvironment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
        }

        public override Dictionary<Type, Func<IConfiguration, IWebHostEnvironment, IServerModule>> InitializeModules()
        {
            var modules = base.InitializeModules();
            modules.Add(typeof(DataIntegrationsServerModule), (config, env) => new DataIntegrationsServerModule(config, env));
            modules.Add(typeof(EmailsServerModule), (config, env) => new EmailsServerModule(config, env));
            modules.Add(typeof(EventStoresServerModule), (config, env) => new EventStoresServerModule(config, env));
            modules.Add(typeof(GoogleIdentityServerModule), (config, env) => new GoogleIdentityServerModule(config, env));
            //modules.Add(typeof(MicrosoftIdentityServerModule), (config, env) => new MicrosoftIdentityServerModule(config, env));
            modules.Add(typeof(OpenIdDictServerModule), (config, env) => new OpenIdDictServerModule(config, env));
            //modules.Add(typeof(QuartzSchedulerServerModule), (config, env) => new QuartzSchedulerServerModule(config, env));
            modules.Add(typeof(RolesServerModule), (config, env) => new RolesServerModule(config, env));
            modules.Add(typeof(UsersServerModule), (config, env) => new UsersServerModule(config, env));
            modules.Add(typeof(UnitsServerModule), (config, env) => new UnitsServerModule(config, env));
            modules.Add(typeof(WorkItemsServerModule), (config, env) => new WorkItemsServerModule(config, env));
            return modules;
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            //services.AddDatabaseDeveloperPageExceptionFilter();
        }
    }
}