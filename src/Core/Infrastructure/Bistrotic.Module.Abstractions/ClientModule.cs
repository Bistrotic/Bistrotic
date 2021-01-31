namespace Fiveforty.Module
{
    using Fiveforty.Module.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class ClientModule : Module, IClientModule
    {
        public ClientModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Client, moduleDefinition, configuration)
        {
        }
    }
}