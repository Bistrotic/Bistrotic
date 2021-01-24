using System.Threading.Tasks;

using Fiveforty.Module.Definitions;

namespace Fiveforty.Module.Abstractions.Tests.Fixture
{
    internal class FakeDuplicatesModuleDefinitionLoader3 : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult(new ModuleDefinition[] {
                new ModuleDefinition("Module1", "Module 1 type"),
                new ModuleDefinition("Module2", "Module 2 type"),
                new ModuleDefinition("Module1", "Module 1 type"),
                new ModuleDefinition("Module3", "Module 3 type")
            });
        }
    }

    internal class FakeEmptyModuleDefinitionLoader2 : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult(new ModuleDefinition[] {
            });
        }
    }

    internal class FakeModuleDefinitionLoader1 : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult(new ModuleDefinition[] {
                new ModuleDefinition("Module1", "Module 1 type"),
                new ModuleDefinition("Module2", "Module 2 type"),
                new ModuleDefinition("Module3", "Module 3 type")
            });
        }
    }

    internal class FakeModuleDefinitionLoader2 : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult(new ModuleDefinition[] {
                new ModuleDefinition("Module4", "Module 4 type"),
                new ModuleDefinition("Module5", "Module 5 type"),
            });
        }
    }
}