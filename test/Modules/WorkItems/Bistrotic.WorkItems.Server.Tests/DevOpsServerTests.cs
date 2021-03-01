namespace Bistrotic.WorkItems.Server.Tests
{
    using Bistrotic.WorkItems.Server.Tests.Fixture;

    using FluentAssertions;

    using Xunit;

    public class DevOpsServerTests : IClassFixture<DevOpsServerFixture>
    {
        private readonly DevOpsServerFixture _serverFixture;

        public DevOpsServerTests(DevOpsServerFixture serverFixture)
        {
            _serverFixture = serverFixture;
        }

        [Fact]
        public void Server_connection()
        {
            var server = _serverFixture.Server;
            server.Connect();
            server.Connection.Should().NotBeNull();
            server.Connection.ServerId.Should().NotBeEmpty();
        }
    }
}