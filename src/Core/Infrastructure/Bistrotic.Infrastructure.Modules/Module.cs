namespace Bistrotic.Infrastructure.Modules
{
    using System;

    using Bistrotic.Infrastructure.Modules.Definitions;

    public abstract class Module : IModule
    {
        protected Module(ModuleType moduleType, ModuleDefinition moduleDefinition)
        {
            ModuleType = moduleType;
            ModuleDefinition = moduleDefinition ?? throw new ArgumentNullException(nameof(moduleDefinition));
        }

        public ModuleDefinition ModuleDefinition { get; }
        public ModuleType ModuleType { get; }
    }
}