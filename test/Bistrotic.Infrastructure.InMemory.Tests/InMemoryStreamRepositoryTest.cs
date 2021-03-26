namespace Bistrotic.Infrastructure.InMemory.Tests
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Abstractions.Tests;
    using Bistrotic.Application.Abstractions.Tests.Fixtures;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.InMemory.Repositories;

    using Xunit;

    public class InMemoryStreamRepositoryTest : RepositoryTestBase
    {
        [Fact]
        protected override Task Check_save_state_to_stream()
        {
            return base.Check_save_state_to_stream();
        }

        protected override IRepository CreateNewRepository()
            => new InMemoryStreamRepository<DummyState>();

        [Fact]
        protected override Task Save_state_throws_not_supported()
        {
            return base.Save_state_throws_not_supported();
        }
    }
}