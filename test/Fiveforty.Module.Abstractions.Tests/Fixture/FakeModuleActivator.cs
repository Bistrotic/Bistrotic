namespace Fiveforty.Module.Abstractions.Tests.Fixture
{
    using System.Threading.Tasks;

    using Fiveforty.Module.Definitions;
    using Fiveforty.Module.Exceptions;

    public class FakeModuleActivator1 : IModuleActivator
    {
        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            switch (definition.TypeName)
            {
                case "FakeModule1":
                    return Task.FromResult<IModule?>(new FakeModule1(definition));

                case "FakeModule2":
                    return Task.FromResult<IModule?>(new FakeModule2(definition));

                case "FakeModule3":
                    return Task.FromResult<IModule?>(new FakeModule3(definition));

                case "FakeModule4":
                    return Task.FromResult<IModule?>(new FakeModule4(definition));

                case "FakeModule5":
                    return Task.FromResult<IModule?>(new FakeModule5(definition));

                case "FakeModule6":
                    return Task.FromResult<IModule?>(new FakeModule6(definition));

                default:
                    break;
            }
            return Task.FromResult<IModule?>(null);
        }

        public async Task<IModule> GetRequiredModule(ModuleDefinition definition)
        {
            return await FindModule(definition) ?? throw new ModuleNotFoundException(definition);
        }
    }

    public class FakeModuleActivator2 : IModuleActivator
    {
        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            switch (definition.TypeName)
            {
                case "FakeModule1":
                    return Task.FromResult<IModule?>(new FakeModule1(definition));

                case "FakeModule2":
                    return Task.FromResult<IModule?>(new FakeModule2(definition));

                case "FakeModule3":
                    return Task.FromResult<IModule?>(new FakeModule3(definition));

                default:
                    break;
            }
            return Task.FromResult<IModule?>(null);
        }

        public async Task<IModule> GetRequiredModule(ModuleDefinition definition)
        {
            return await FindModule(definition) ?? throw new ModuleNotFoundException(definition);
        }
    }

    public class FakeModuleActivator3 : IModuleActivator
    {
        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            switch (definition.TypeName)
            {
                case "FakeModule4":
                    return Task.FromResult<IModule?>(new FakeModule4(definition));

                case "FakeModule5":
                    return Task.FromResult<IModule?>(new FakeModule5(definition));

                case "FakeModule6":
                    return Task.FromResult<IModule?>(new FakeModule6(definition));

                default:
                    break;
            }
            return Task.FromResult<IModule?>(null);
        }

        public async Task<IModule> GetRequiredModule(ModuleDefinition definition)
        {
            return await FindModule(definition) ?? throw new ModuleNotFoundException(definition);
        }
    }
}