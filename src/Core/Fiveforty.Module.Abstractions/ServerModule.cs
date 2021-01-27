namespace Fiveforty.Module.Abstractions
{
    using Fiveforty.Module.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class ServerModule : Module
    {
        public ServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Server, moduleDefinition, configuration)
        {
        }
    }
}