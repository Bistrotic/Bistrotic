namespace Fiveforty.Module
{
    using Fiveforty.Module.Definitions;

    public abstract class ClientModule : Module, IClientModule
    {
        public ClientModule(ModuleDefinition moduleDefinition) : base(ModuleType.Client, moduleDefinition)
        {
        }
    }
}