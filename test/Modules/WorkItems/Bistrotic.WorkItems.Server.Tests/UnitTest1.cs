namespace Bistrotic.WorkItems.Server.Tests
{
    using System;

    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Infrastructure.DevOps;

    using FluentAssertions;

    using Microsoft.Extensions.Configuration;

    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Server_connection()
        {
            var settings = GetSettings();
            var server = new DevOpsServer(settings.AzureDevOpsServerUrl ?? string.Empty, settings.PersonalAccessToken ?? string.Empty);
            server.Connect();
            server.Connection.Should().NotBeNull();
        }

        private static WorkItemModuleSettings GetSettings()
        {
            // the type specified here is just so the secrets library can find the UserSecretId we
            // added in the csproj file
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<WorkItemModuleSettings>();

            return builder.Build().GetSection(nameof(WorkItemModuleSettings)).Get<WorkItemModuleSettings>();
        }
    }
}