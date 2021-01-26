namespace Fiveforty.Module
{
    using System;

    using Fiveforty.Module.Definitions;

    public abstract class Module : IModule
    {
        public Module(ModuleType moduleType, ModuleDefinition moduleDefinition)
        {
            ModuleType = moduleType;
            ModuleDefinition = moduleDefinition ?? throw new ArgumentNullException(nameof(moduleDefinition));
        }

        public ModuleDefinition ModuleDefinition { get; }

        public ModuleType ModuleType { get; }
    }
}