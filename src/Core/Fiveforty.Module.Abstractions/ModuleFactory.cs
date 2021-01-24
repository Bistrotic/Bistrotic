namespace Fiveforty.Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fiveforty.Module.Definitions;
    using Fiveforty.Module.Exceptions;

    public class ModuleFactory : IModuleFactory
    {
        private readonly IEnumerable<Func<IModuleDefinitionLoader>> _definitionLoaderFuncs;
        private readonly IEnumerable<Func<IModuleActivator>> _moduleActivatorFuncs;
        private IEnumerable<IModuleActivator>? _moduleActivators;
        private List<ModuleDefinition>? _moduleDefinitions;
        private Dictionary<string, ModuleDefinition>? _moduleDefinitionsByName;

        public ModuleFactory(IEnumerable<Func<IModuleDefinitionLoader>> definitionLoaders, IEnumerable<Func<IModuleActivator>> moduleActivators)
        {
            _definitionLoaderFuncs = definitionLoaders ?? throw new ArgumentNullException(nameof(definitionLoaders));
            if (!_definitionLoaderFuncs.Any())
            {
                throw new ArgumentException("No definition loaders defined.", nameof(definitionLoaders));
            }
            _moduleActivatorFuncs = moduleActivators ?? throw new ArgumentNullException(nameof(moduleActivators));
            if (!_moduleActivatorFuncs.Any())
            {
                throw new ArgumentException("No module activators defined.", nameof(moduleActivators));
            }
        }

        public async Task<IEnumerable<IModule>> GetModules()
        {
            var definitions = await GetModuleDefinitions();
            return await Task.WhenAll(definitions
                .Select(p => GetModule(p))
                .ToArray()
            );
        }

        private IEnumerable<ModuleDefinition> GetDependencies(IEnumerable<ModuleDefinition> dependencies)
        {
            _ = _moduleDefinitionsByName ??= GetModuleDefinitionsByName().GetAwaiter().GetResult();
            List<ModuleDefinition> list = new();
            foreach (ModuleDefinition definition in dependencies)
            {
                if (definition.Dependencies.Any())
                {
                    list.AddRange(GetDependencies(GetModuleDefinitionDependencies(definition)));
                }
                list.Add(definition);
            }
            return list;
        }

        private async Task<IModule> GetModule(ModuleDefinition moduleDefinition)
        {
            var activators = await GetModuleActivators();
            foreach (var activator in activators)
            {
                var module = await activator.GetModule(moduleDefinition);
                if (module != null)
                {
                    return module;
                }
            }
            throw new InvalidModuleDefinitionException(moduleDefinition, $"Module {moduleDefinition.Name} not found.");
        }

        private Task<IEnumerable<IModuleActivator>> GetModuleActivators()
        {
            if (_moduleActivators == null)
            {
                _moduleActivators = _moduleActivatorFuncs.Select(p => p()).ToArray();
            }
            return Task.FromResult(_moduleActivators);
        }

        private List<ModuleDefinition> GetModuleDefinitionDependencies(ModuleDefinition module)
        {
            _ = _moduleDefinitionsByName ??= GetModuleDefinitionsByName().GetAwaiter().GetResult();
            List<ModuleDefinition> list = new List<ModuleDefinition>(module.Dependencies.Length);
            foreach (string dependencyName in module.Dependencies)
            {
                if (!_moduleDefinitionsByName.TryGetValue(dependencyName, out ModuleDefinition? moduleDefinition))
                {
                    throw new ModuleDefinitionDependencyNotFoundException(module, dependencyName);
                }
                list.Add(moduleDefinition);
            }
            return list;
        }

        private async Task<List<ModuleDefinition>> GetModuleDefinitions()
        {
            if (_moduleDefinitions == null)
            {
                var definitions = await GetModuleDefinitionsByName();
                var list = new List<ModuleDefinition>(definitions.Count);
                var added = new HashSet<string>(definitions.Count);
                foreach (var definition in definitions.OrderByDescending(p => p.Value.Priority))
                {
                }
                _moduleDefinitions = list;
            }
            return _moduleDefinitions;
        }

        private async Task<Dictionary<string, ModuleDefinition>> GetModuleDefinitionsByName()
        {
            if (_moduleDefinitionsByName == null)
            {
                var loaders = _definitionLoaderFuncs.Select(p => p()).ToArray();
                var definitionsTasks = loaders.Select(p => p.GetDefinitions()).ToArray();
                var definitions = (await Task.WhenAll(definitionsTasks)).SelectMany(p => p);
                var duplicates = definitions
                          .GroupBy(p => p.NormalizedName)
                          .Where(p => p.Count() > 1)
                          .Select(p => p.Key);
                if (duplicates.Any())
                {
                    throw new DuplicateModuleDefinitionException(duplicates.ToArray());
                }
                _moduleDefinitionsByName = definitions.ToDictionary(k => k.NormalizedName, v => v);
            }
            return _moduleDefinitionsByName;
        }
    }
}