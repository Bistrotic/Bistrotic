﻿namespace Fiveforty.Module.Abstractions.Tests.Fixture
{
    using Fiveforty.Module.Definitions;

    using Microsoft.Extensions.Configuration;

    public class FakeModule1 : ServiceModule, IModule
    {
        public FakeModule1(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule2 : ServiceModule, IModule
    {
        public FakeModule2(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule3 : ServiceModule, IModule
    {
        public FakeModule3(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule4 : ServiceModule, IModule
    {
        public FakeModule4(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule5 : ServiceModule, IModule
    {
        public FakeModule5(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }

    public class FakeModule6 : ServiceModule, IModule
    {
        public FakeModule6(ModuleDefinition definition, IConfiguration configuration) : base(definition, configuration)
        {
        }
    }
}