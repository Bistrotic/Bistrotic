namespace Bistrotic.Infrastructure.MicrosoftGraph.Tests
{
    using System.Threading.Tasks;

    using Bistrotic.Infrastructure.MicrosoftGraph.Tests.Fixture;

    using FluentAssertions;

    using Xunit;

    public class GraphServiceTest : IClassFixture<GraphFixture>
    {
        private readonly GraphFixture _graphFixture;

        public GraphServiceTest(GraphFixture graphFixture)
        {
            _graphFixture = graphFixture;
        }

        [Fact]
        public async Task get_user_ids_should_not_be_empty()
        {
            var userIds = await _graphFixture
                .GraphService
                .GetUserIds();
            userIds.Should().NotBeNull();
            userIds.Should().NotBeEmpty();
        }
    }
}