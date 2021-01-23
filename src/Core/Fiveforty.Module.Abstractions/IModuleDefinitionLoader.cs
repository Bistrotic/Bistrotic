namespace Fiveforty.Module
{
    using System.Threading.Tasks;

    public interface IModuleDefinitionLoader
    {
        Task<ModuleDefinition[]> GetDefinitions();
    }
}