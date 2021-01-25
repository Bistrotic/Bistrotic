using System;

using Fiveforty.Module.Definitions;

namespace Fiveforty.Module
{
    public abstract class Module : IModule
    {
        private ModuleDefinition _moduleDefinition;

        public Module(ModuleDefinition? moduleDefinition = null)
        {
            _moduleDefinition = moduleDefinition ?? throw new ArgumentNullException(nameof(moduleDefinition));
        }

        public ModuleDefinition ModuleDefinition => _moduleDefinition;
    }
}