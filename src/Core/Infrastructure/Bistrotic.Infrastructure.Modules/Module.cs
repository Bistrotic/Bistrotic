namespace Bistrotic.Infrastructure.Modules
{
    using System;

    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public abstract class Module : IModule
    {
        public Module(ModuleType moduleType, ModuleDefinition moduleDefinition, IConfiguration configuration)
        {
            ModuleType = moduleType;
            ModuleDefinition = moduleDefinition ?? throw new ArgumentNullException(nameof(moduleDefinition));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ModuleDefinition ModuleDefinition { get; }
        public ModuleType ModuleType { get; }
    }
}