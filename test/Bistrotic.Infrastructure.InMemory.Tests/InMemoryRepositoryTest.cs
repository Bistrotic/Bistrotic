namespace Bistrotic.Infrastructure.InMemory.Tests
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Abstractions.Tests;
    using Bistrotic.Application.Abstractions.Tests.Fixtures;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.InMemory.Repositories;

    using Xunit;

    public class InMemoryRepositoryTest : RepositoryTestBase
    {
        [Fact]
        protected override Task Check_save_state()
        {
            return base.Check_save_state();
        }

        protected override IRepository CreateNewRepository()
                    => new InMemoryRepository<IDummyState, DummyState>();

        [Fact]
        protected override Task Save_stream_throws_not_supported()
        {
            return base.Save_stream_throws_not_supported();
        }
    }
}