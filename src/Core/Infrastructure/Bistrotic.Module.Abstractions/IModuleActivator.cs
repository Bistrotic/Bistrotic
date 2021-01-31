namespace Fiveforty.Module
{
    using System.Threading.Tasks;

    using Fiveforty.Module.Definitions;

    public interface IModuleActivator
    {
        Task<IModule?> FindModule(ModuleDefinition definition);

        Task<IModule> GetRequiredModule(ModuleDefinition definition);
    }
}