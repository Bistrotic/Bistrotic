namespace Fiveforty.Module.Abstractions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fiveforty.Module.Abstractions.Tests.Fixture;
    using Fiveforty.Module.Definitions;
    using Fiveforty.Module.Exceptions;

    using FluentAssertions;

    using Xunit;

    public class ModuleFactoryTests
    {
        [Fact]
        public async Task GetModules_FromOneLoaderAndOneActivator()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionLoader1()
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator1()
            });
            (await factory.GetModules())
                .Should()
                .HaveCount(6);
        }

        [Fact]
        public async Task GetModules_FromTwoActivators()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionLoader1(),
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator2(),
                () => new FakeModuleActivator3()
            });
            (await factory.GetModules())
                .Should()
                .HaveCount(6);
        }

        [Fact]
        public Task GetModules_WithCircularDependency()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionWithCircularDependenciesLoader(),
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator1()
            });
            factory
                .Invoking(p => p.GetModules())
                .Should()
                .Throw<ModuleDefinitionCircularDependencyException>()
                .WithMessage("*module1 with dependency module6*");
            return Task.CompletedTask;
        }

        [Fact]
        public async Task GetModules_WithDependencies()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionWithDependenciesLoader(),
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator1()
            });
            var modules = await factory.GetModules();
            modules
                .Select(p => p.GetDefinition().Name)
                .ToArray()
                .Should()
                .ContainInOrder("Module1", "Module2", "Module3", "Module4", "Module5", "Module6");
            modules
                .Should()
                .HaveCount(6);
        }

        [Fact]
        public async Task GetModules_WithDuplicateActivations()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionLoader1()
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator1(),
                () => new FakeModuleActivator2()
            });
            (await factory.GetModules())
                .Should()
                .HaveCount(6);
        }

        [Fact]
        public Task GetModules_WithDuplicateModuleDefinitions()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeDuplicatesModuleDefinitionLoader(),
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator1()
            });
            factory
                .Invoking(p => p.GetModules())
                .Should()
                .Throw<DuplicateModuleDefinitionException>()
                .WithMessage("*Module1*Module4*");
            return Task.CompletedTask;
        }

        [Fact]
        public async Task GetModules_WithPriority()
        {
            var factory = new ModuleFactory(
                new List<Func<IModuleDefinitionLoader>> {
                () => new FakeModuleDefinitionWithPrioriryLoader(),
                },
                new List<Func<IModuleActivator>> {
                () => new FakeModuleActivator1()
            });
            var modules = await factory.GetModules();
            modules
                .Should()
                .HaveCount(6);
            modules
                .Select(p => p.GetDefinition().Name)
                .ToArray()
                .Should()
                .ContainInOrder("Module1", "Module2", "Module3", "Module4", "Module5", "Module6");
        }
    }
}