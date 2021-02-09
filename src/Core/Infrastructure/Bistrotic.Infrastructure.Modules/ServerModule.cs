namespace Bistrotic.Infrastructure.Modules
{
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class ServerModule : Module, IServerModule
    {
        protected ServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Server, moduleDefinition, configuration)
        {
        }

        public abstract void ConfigureServices(IServiceCollection services);
    }
}