namespace Bistrotic.Infrastructure.BlazorClient
{
    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class ClientModule : Module, IClientModule
    {
        protected readonly string _clientName;
        protected readonly string _serverApiName;

        protected ClientModule(ModuleDefinition moduleDefinition, IWebAssemblyHostEnvironment hostEnvironment, string clientName, string serverApiName)
                    : base(ModuleType.Client, moduleDefinition)
        {
            Environment = hostEnvironment;
            _clientName = clientName;
            _serverApiName = serverApiName;
        }

        public IWebAssemblyHostEnvironment Environment { get; }

        public abstract void ConfigureServices(IServiceCollection services);
    }
}