namespace Fiveforty.Module.Abstractions.Tests
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public class ModuleFactoryTests
    {
        [Fact]
        public void Test1()
        {
            var factory = new ModuleFactory(new List<Func<IModuleDefinitionLoader>> {
                () => new FakeLoader()
            });
        }
    }
}