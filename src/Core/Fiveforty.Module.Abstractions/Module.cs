using Fiveforty.Module.Definitions;

namespace Fiveforty.Module
{
    public abstract class Module : IModule
    {
        public abstract ModuleDefinition GetDefinition();
    }
}