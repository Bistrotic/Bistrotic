namespace Fiveforty.Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModuleFactory : IModuleFactory
    {
        private readonly IEnumerable<Func<IModuleDefinitionLoader>> _definitionLoaders;
        private Dictionary<string, ModuleDefinition>? _modulesByName;

        public ModuleFactory(IEnumerable<Func<IModuleDefinitionLoader>> definitionLoaders)
        {
            _definitionLoaders = definitionLoaders ?? throw new ArgumentNullException(nameof(definitionLoaders));
        }

        private Dictionary<string, ModuleDefinition> ModulesByName => _modulesByName ??= InitModulesByName().GetAwaiter().GetResult();

        public Task<IEnumerable<IModule>> GetModules()
        {
            throw new NotImplementedException();
        }

        private async Task<Dictionary<string, ModuleDefinition>> InitModulesByName()
        {
            var loaders = _definitionLoaders.Select(p => p()).ToArray();
            var definitionsTasks = loaders.Select(p => p.GetDefinitions()).ToArray();
            var definitions = await Task.WhenAll(definitionsTasks);
            return definitions.SelectMany(p => p).ToDictionary(k => k.Name, v => v);
        }
    }
}