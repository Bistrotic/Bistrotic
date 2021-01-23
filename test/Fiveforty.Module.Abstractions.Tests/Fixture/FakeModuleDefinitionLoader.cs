using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiveforty.Module.Abstractions.Tests.Fixture
{
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

    internal class FakeModuleDefinitionLoader3 : IModuleDefinitionLoader
    {
        public Task<ModuleDefinition[]> GetDefinitions()
        {
            return Task.FromResult(new ModuleDefinition[] {
                new ModuleDefinition("Module1", "Module2")
            });
        }
    }
}