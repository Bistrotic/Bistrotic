namespace Fiveforty.Module.Abstractions
{
    using Fiveforty.Module.Definitions;

    public abstract class ServiceModule : Module
    {
        public ServiceModule(ModuleDefinition moduleDefinition) : base(ModuleType.Server, moduleDefinition)
        {
        }
    }
}