namespace Bistrotic.Module.Abstractions.Tests.Fixture
{
    using Bistrotic.Infrastructure.Modules;
    using Bistrotic.Infrastructure.Modules.Abstractions;
    using Bistrotic.Infrastructure.Modules.Definitions;

    using Microsoft.Extensions.Configuration;

    public class FakeModule1 : ServiceModule
    {
        public FakeModule1(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule2 : ServiceModule
    {
        public FakeModule2(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule3 : ServiceModule
    {
        public FakeModule3(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule4 : ServiceModule
    {
        public FakeModule4(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule5 : ServiceModule
    {
        public FakeModule5(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule6 : ServiceModule
    {
        public FakeModule6(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }
}