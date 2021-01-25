using Fiveforty.Module.Definitions;

namespace Fiveforty.Module.Abstractions.Tests.Fixture
{
    public class FakeModule1 : IModule
    {
        private readonly ModuleDefinition _definition;

        public FakeModule1(ModuleDefinition definition)
        {
            _definition = definition;
        }

        public ModuleDefinition GetDefinition() => _definition;
    }

    public class FakeModule2 : IModule
    {
        private readonly ModuleDefinition _definition;

        public FakeModule2(ModuleDefinition definition)
        {
            _definition = definition;
        }

        public ModuleDefinition GetDefinition() => _definition;
    }

    public class FakeModule3 : IModule
    {
        private readonly ModuleDefinition _definition;

        public FakeModule3(ModuleDefinition definition)
        {
            _definition = definition;
        }

        public ModuleDefinition GetDefinition() => _definition;
    }

    public class FakeModule4 : IModule
    {
        private readonly ModuleDefinition _definition;

        public FakeModule4(ModuleDefinition definition)
        {
            _definition = definition;
        }

        public ModuleDefinition GetDefinition() => _definition;
    }

    public class FakeModule5 : IModule
    {
        private readonly ModuleDefinition _definition;

        public FakeModule5(ModuleDefinition definition)
        {
            _definition = definition;
        }

        public ModuleDefinition GetDefinition() => _definition;
    }

    public class FakeModule6 : IModule
    {
        private readonly ModuleDefinition _definition;

        public FakeModule6(ModuleDefinition definition)
        {
            _definition = definition;
        }

        public ModuleDefinition GetDefinition() => _definition;
    }
}