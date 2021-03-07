﻿namespace Bistrotic.Infrastructure.Abstractions.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Bistrotic.Infrastructure.Abstractions.Tests.Fixtures;
    using Bistrotic.Infrastructure.Helpers;

    using FluentAssertions;

    using Microsoft.Extensions.Configuration;

    using Xunit;

    public class ConfigurationHelperTest
    {
        private static IConfiguration CreateConfiguration<TSettings>(TSettings settings)
            => new ConfigurationBuilder()
                .AddInMemoryCollection(settings?.GetPropertyValues().ToDictionary(k => typeof(TSettings).Name+":"+k.Key, v => v.Value?.ToString()))
                .Build();
        [Fact]
        public void GetSettings_should_set_correctly_all_values()
        {
            var configurationValues = new DummySettings {
                String = "test string",
                InitOnlyString = "init only test string"
            };
            IConfiguration configuration = CreateConfiguration(configurationValues);
            var settings = configuration.GetSettings<DummySettings>();
            settings.Should().BeEquivalentTo(configurationValues);

        }

    }
}
