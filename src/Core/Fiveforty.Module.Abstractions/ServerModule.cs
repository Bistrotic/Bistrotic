namespace Fiveforty.Module.Abstractions
{
    using Fiveforty.Module.Definitions;

    public abstract class ServerModule : Module
    {
        public ServerModule(ModuleDefinition moduleDefinition) : base(ModuleType.Server, moduleDefinition)
        {
        }
    }
}