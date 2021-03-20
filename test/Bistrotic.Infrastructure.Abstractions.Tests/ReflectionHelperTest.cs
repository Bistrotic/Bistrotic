namespace Bistrotic.Infrastructure.Abstractions.Tests
{
    using Bistrotic.Infrastructure.Abstractions.Tests.Fixtures;
    using Bistrotic.Infrastructure.Helpers;

    using FluentAssertions;

    using Xunit;

    public class ReflectionHelperTest
    {
        [Fact]
        public void GetPropertyNotNullValues_should_not_return_null_values()
        {
            var properties = new DummyObject().GetPropertyNotNullValues();
            properties.Should().NotContainKey(nameof(DummyObject.ANullString));
        }

        [Fact]
        public void GetPropertyValues_should_contain_all_properties()
        {
            var properties = new DummyObject().GetPropertyValues();
            properties.Should().Contain(nameof(DummyObject.AString));
        }

        [Fact]
        public void GetPropertyValues_should_not_return_private_properties()
        {
            var properties = new DummyObject().GetPropertyValues();
            properties.Should().NotContain("_aPrivateFieldNullString");
            properties.Should().NotContain("_aPrivateFieldString");
            properties.Should().NotContain("APrivateString");
        }
    }
}