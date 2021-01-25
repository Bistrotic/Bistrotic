namespace Fiveforty.Module.Definitions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    public class ReflectionModuleDefinitionLoader : IModuleDefinitionLoader
    {
        private readonly ILogger _log;

        public ReflectionModuleDefinitionLoader(ILogger<ReflectionModuleDefinitionLoader> logger)
        {
            _log = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult(AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(p => p.GetTypes())
                .Where(p => typeof(IModule).IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .Select(p => GetModuleDefinition(p))
                .ToArray()
                );
        }

        private ModuleDefinition GetModuleDefinition(Type moduleType)
            => new ModuleDefinition(
                moduleType.Name,
                moduleType.AssemblyQualifiedName
                    ?? throw new Exception($"Type {moduleType.FullName} has an empty assembly qualified name.")
                );
    }
}