namespace Bistrotic.Infrastructure.Modules
{
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class ServiceModule : ModuleBase
    {
        protected ServiceModule(ModuleDefinition moduleDefinition, IConfiguration configuration) : base(ModuleType.Server, moduleDefinition)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
    }
}