namespace Bistrotic.Infrastructure.WebServer.Modules
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure.Modules.Definitions;

    public class ReflectionServerModuleDefinitionLoader : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
            => Task.FromResult(AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(p => p.GetTypes())
                .Where(p => p.IsClass && !p.IsAbstract && typeof(IServerModule).IsAssignableFrom(p))
                .Select(p => GetModuleDefinition(p))
                .ToArray()
                );

        private static ModuleDefinition GetModuleDefinition(Type moduleType)
            => new ModuleDefinition(
                moduleType.Name,
                moduleType.AssemblyQualifiedName
                    ?? throw new Exception($"Type {moduleType.FullName} has an empty assembly qualified name.")
                );
    }
}