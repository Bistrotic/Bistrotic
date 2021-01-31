namespace Bistrotic.Infrastructure.Modules
{
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure.Modules.Definitions;

    public interface IModuleActivator
    {
        Task<IModule?> FindModule(ModuleDefinition definition);

        Task<IModule> GetRequiredModule(ModuleDefinition definition);
    }
}