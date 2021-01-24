namespace Fiveforty.Module.Abstractions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fiveforty.Module.Abstractions.Tests.Fixture;
    using Fiveforty.Module.Definitions;

    using FluentAssertions;

    using Xunit;

    public class ModuleFactoryTests
    {
        [Fact]
        public async Task Test1()
        {
            var factory = new ModuleFactory(new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionLoader1(),
                () => new FakeModuleDefinitionLoader2()
            });
            (await factory.GetModules())
                .Should()
                .HaveCount(5);
        }
    }
}