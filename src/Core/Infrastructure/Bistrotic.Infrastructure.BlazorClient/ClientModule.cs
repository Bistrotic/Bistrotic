namespace Bistrotic.Infrastructure.BlazorClient
{
    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class ClientModule : ModuleBase, IClientModule
    {
        protected ClientModule(ModuleDefinition moduleDefinition, IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName, ClientMode clientMode)
                    : base(ModuleType.Client, moduleDefinition)
        {
            Environment = hostEnvironment;
            ClientName = clientName;
            ServerApiName = serverApiName;
            ClientMode = clientMode;
        }

        public IWebAssemblyHostEnvironment Environment { get; }
        protected ClientMode ClientMode { get; }

        protected string ClientName { get; }
        protected string ServerApiName { get; }

        public abstract void ConfigureServices(IServiceCollection services);
    }
}