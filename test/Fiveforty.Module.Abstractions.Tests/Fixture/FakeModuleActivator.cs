namespace Fiveforty.Module.Abstractions.Tests.Fixture
{
    using System.Threading.Tasks;

    using Fiveforty.Module.Definitions;
    using Fiveforty.Module.Exceptions;

    using Microsoft.Extensions.Configuration;

    public class FakeModuleActivator1 : IModuleActivator
    {
        private readonly IConfiguration _configuration;

        public FakeModuleActivator1(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            switch (definition.TypeName)
            {
                case "FakeModule1":
                    return Task.FromResult<IModule?>(new FakeModule1(definition, _configuration));

                case "FakeModule2":
                    return Task.FromResult<IModule?>(new FakeModule2(definition, _configuration));

                case "FakeModule3":
                    return Task.FromResult<IModule?>(new FakeModule3(definition, _configuration));

                case "FakeModule4":
                    return Task.FromResult<IModule?>(new FakeModule4(definition, _configuration));

                case "FakeModule5":
                    return Task.FromResult<IModule?>(new FakeModule5(definition, _configuration));

                case "FakeModule6":
                    return Task.FromResult<IModule?>(new FakeModule6(definition, _configuration));

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
        private readonly IConfiguration _configuration;

        public FakeModuleActivator2(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            switch (definition.TypeName)
            {
                case "FakeModule1":
                    return Task.FromResult<IModule?>(new FakeModule1(definition, _configuration));

                case "FakeModule2":
                    return Task.FromResult<IModule?>(new FakeModule2(definition, _configuration));

                case "FakeModule3":
                    return Task.FromResult<IModule?>(new FakeModule3(definition, _configuration));

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
        private readonly IConfiguration _configuration;

        public FakeModuleActivator3(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<IModule?> FindModule(ModuleDefinition definition)
        {
            switch (definition.TypeName)
            {
                case "FakeModule4":
                    return Task.FromResult<IModule?>(new FakeModule4(definition, _configuration));

                case "FakeModule5":
                    return Task.FromResult<IModule?>(new FakeModule5(definition, _configuration));

                case "FakeModule6":
                    return Task.FromResult<IModule?>(new FakeModule6(definition, _configuration));

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