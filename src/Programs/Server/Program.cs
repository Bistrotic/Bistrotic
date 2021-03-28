namespace Bistrotic.Server
{
    using System.Threading.Tasks;

    using Bistrotic.DataIntegrations;
    using Bistrotic.Emails;
    using Bistrotic.EventStores;
    using Bistrotic.GoogleIdentity;
    using Bistrotic.Infrastructure.WebServer;
    using Bistrotic.MicrosoftIdentity;
    using Bistrotic.OpenIdDict;
    using Bistrotic.QuartzScheduler;
    using Bistrotic.Roles;
    using Bistrotic.Units;
    using Bistrotic.Users;
    using Bistrotic.WorkItems;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program : ServerProgram<Startup>
    {
        public Program(string[] args) : base(args)
        {
        }

        // EF Core uses this method at design time to access the DbContext
        public static IHostBuilder CreateHostBuilder(string[] args)
            => new Program(args).HostBuilder;

        public static Task Main(string[] args)
            => new Program(args).Host.RunAsync();

        public override void AddModules(IServiceCollection services)
        {
            AddModule<DataIntegrationsServerModule>(services);
            AddModule<EmailsServerModule>(services);
            AddModule<EventStoresServerModule>(services);
            AddModule<GoogleIdentityServerModule>(services);
            AddModule<MicrosoftIdentityServerModule>(services);
            AddModule<OpenIdDictServerModule>(services);
            AddModule<QuartzSchedulerServerModule>(services);
            AddModule<RolesServerModule>(services);
            AddModule<UsersServerModule>(services);
            AddModule<UnitsServerModule>(services);
            AddModule<WorkItemsServerModule>(services);
        }
    }
}