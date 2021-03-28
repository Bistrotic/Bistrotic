namespace Bistrotic.Server
{
    using System.Threading.Tasks;

    using Bistrotic.DataIntegrations;
    using Bistrotic.Emails;
    using Bistrotic.EventStores;
    using Bistrotic.GoogleIdentity;
    using Bistrotic.Infrastructure.WebServer;
    using Bistrotic.Infrastructure.WebServer.Modules;
    using Bistrotic.MicrosoftIdentity;
    using Bistrotic.OpenIdDict;
    using Bistrotic.QuartzScheduler;
    using Bistrotic.Roles;
    using Bistrotic.Units;
    using Bistrotic.Users;
    using Bistrotic.WorkItems.Server;

    using Microsoft.Extensions.DependencyInjection;

    public static class Program
    {
        public static Task Main(string[] args)
            => ServerProgram
                .CreateHostBuilder<Startup>(args)
                .ConfigureServices(p =>
                {
                    p.AddSingleton<IServerModule, DataIntegrationsServerModule>();
                    p.AddSingleton<IServerModule, EmailsServerModule>();
                    p.AddSingleton<IServerModule, EventStoresServerModule>();
                    p.AddSingleton<IServerModule, GoogleIdentityServerModule>();
                    p.AddSingleton<IServerModule, MicrosoftIdentityServerModule>();
                    p.AddSingleton<IServerModule, OpenIdDictServerModule>();
                    p.AddSingleton<IServerModule, QuartzSchedulerServerModule>();
                    p.AddSingleton<IServerModule, RolesServerModule>();
                    p.AddSingleton<IServerModule, UsersServerModule>();
                    p.AddSingleton<IServerModule, UnitsServerModule>();
                    p.AddSingleton<IServerModule, WorkItemsServerModule>();
                })
                .Build()
                .StartAsync();
    }
}