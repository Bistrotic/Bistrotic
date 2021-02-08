namespace Bistrotic.Infrastructure.Modules.Abstractions
{
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class ServerModule : Module
    {
        protected ServerModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Server, moduleDefinition, configuration)
        {
        }
    }
}