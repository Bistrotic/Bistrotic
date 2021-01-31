namespace Bistrotic.Infrastructure.Modules.Definitions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReflectionModuleDefinitionLoader : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult<ModuleDefinition[]>(AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(p => p.GetTypes())
                .Where(p => typeof(IModule).IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .Select(p => GetModuleDefinition(p))
                .ToArray()
                );
        }

        private static ModuleDefinition GetModuleDefinition(Type moduleType)
            => new ModuleDefinition(
                moduleType.Name,
                moduleType.AssemblyQualifiedName
                    ?? throw new Exception($"Type {moduleType.FullName} has an empty assembly qualified name.")
                );
    }
}