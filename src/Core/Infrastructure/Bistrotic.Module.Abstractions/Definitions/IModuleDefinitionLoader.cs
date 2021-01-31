namespace Fiveforty.Module.Definitions
{
    using System.Threading.Tasks;

    public interface IModuleDefinitionLoader
    {
        Task<ModuleDefinition[]> GetDefinitions();
    }
}