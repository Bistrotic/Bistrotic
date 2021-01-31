namespace Bistrotic.Infrastructure.Modules
{
    using Bistrotic.Infrastructure.Modules.Definitions;

    public interface IModule
    {
        ModuleDefinition ModuleDefinition { get; }
    }
}