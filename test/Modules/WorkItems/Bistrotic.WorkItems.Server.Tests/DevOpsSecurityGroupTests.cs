namespace Bistrotic.WorkItems.Server.Tests
{
    using System.Threading.Tasks;

    using Bistrotic.WorkItems.Infrastructure.DevOps;
    using Bistrotic.WorkItems.Server.Tests.Fixture;

    using FluentAssertions;

    using Microsoft.VisualStudio.Services.Graph.Client;

    using Xunit;

    public class DevOpsSecurityGroupTests : IClassFixture<DevOpsServerFixture>
    {
        private readonly DevOpsServerFixture _serverFixture;

        public DevOpsSecurityGroupTests(DevOpsServerFixture serverFixture)
        {
            _serverFixture = serverFixture;
        }

        [Fact]
        public async Task GetGroup_should_return_a_group_with_same_name()
        {
            var groupName = _serverFixture.Settings.SlaGroupName ?? string.Empty;
            groupName.Should().NotBeNullOrWhiteSpace();
            var server = _serverFixture.Server;
            server.Connect();
            var devOpsgroup = new DevOpsGroup(server, groupName);
            GraphGroup graphGroup = await devOpsgroup.GetGroup();
            graphGroup.PrincipalName
                .Should()
                .Be(groupName);
        }
    }
}