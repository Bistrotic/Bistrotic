namespace Fiveforty.Infrastructure.Tests
{
    using Fiveforty.Infrastructure.Reflection;
    using Fiveforty.Infrastructure.Tests.Fixture;

    using FluentAssertions;

    using System;

    using Xunit;

    public class ReflectionHelperTest
    {
        [Fact]
        public void Assembly_GetConcreteClasses()
        {
            var result = GetType().Assembly.GetConcreteClasses<ITestInterface>();
            result.Should().HaveCount(5);
            result.Should().Contain(new Type[] { typeof(TestConcrete1), typeof(TestConcrete2), typeof(TestConcrete3), typeof(TestConcrete4), typeof(TestConcrete5) });
        }

        [Fact]
        public void AssemblyGetConcreteClasses_NoClasses()
        {
            var result = GetType().Assembly.GetConcreteClasses<ITestInterfaceNoClass>();
            result.Should().HaveCount(0);
        }

        [Fact]
        public void GetInterfaceConcreteClassTypes()
        {
            var result = ReflectionHelper.GetInterfaceConcreteClassTypes(this.GetType().Assembly, typeof(ITestInterface));
            result.Should().HaveCount(5);
            result.Should().Contain(new Type[] { typeof(TestConcrete1), typeof(TestConcrete2), typeof(TestConcrete3), typeof(TestConcrete4), typeof(TestConcrete5) });
        }

        [Fact]
        public void GetInterfaceConcreteClassTypes_Generic()
        {
            var result = ReflectionHelper.GetInterfaceConcreteClassTypes(this.GetType().Assembly, typeof(ITestInterface<>));
            result.Should().HaveCount(2);
            result.Should().Contain(new Type[] { typeof(TestConcrete4), typeof(TestConcrete5) });
        }

        [Fact]
        public void GetInterfaceConcreteClassTypes_NoClasses()
        {
            var result = ReflectionHelper.GetInterfaceConcreteClassTypes(this.GetType().Assembly, typeof(ITestInterfaceNoClass));
            result.Should().HaveCount(0);
        }

        [Fact]
        public void Type_GetConcreteClasses()
        {
            var result = typeof(ITestInterface).GetConcreteClasses(this.GetType().Assembly);
            result.Should().HaveCount(5);
            result.Should().Contain(new Type[] { typeof(TestConcrete1), typeof(TestConcrete2), typeof(TestConcrete3), typeof(TestConcrete4), typeof(TestConcrete5) });
        }

        [Fact]
        public void Type_GetConcreteClasses_NoClasses()
        {
            var result = typeof(ITestInterfaceNoClass).GetConcreteClasses(this.GetType().Assembly);
            result.Should().HaveCount(0);
        }
    }
}