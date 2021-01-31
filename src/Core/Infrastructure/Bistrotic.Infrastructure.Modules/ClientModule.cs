namespace Bistrotic.Infrastructure.Modules
{
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class ClientModule : Module, IClientModule
    {
        public ClientModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Client, moduleDefinition, configuration)
        {
        }
    }
}