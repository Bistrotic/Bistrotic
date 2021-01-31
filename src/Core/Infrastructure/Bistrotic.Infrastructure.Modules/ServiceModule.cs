namespace Bistrotic.Infrastructure.Modules.Abstractions
{
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class ServiceModule : Module
    {
        public ServiceModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Server, moduleDefinition, configuration)
        {
        }
    }
}