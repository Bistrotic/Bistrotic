namespace Bistrotic.Infrastructure.EfCore.Tests
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Abstractions.Tests;
    using Bistrotic.Application.Abstractions.Tests.Fixtures;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.EfCore.Repositories;

    using Microsoft.Extensions.Logging;

    using Moq;

    using TestSupport.EfHelpers;

    using Xunit;

    public class EfRepositoryTest : RepositoryTestBase
    {
        [Fact]
        protected override Task Check_save_state_to_stream()
        {
            return base.Check_save_state_to_stream();
        }

        [Fact]
        protected override Task Check_set_new_state()
        {
            return base.Check_set_new_state();
        }

        [Fact]
        protected override Task Check_update_state()
        {
            return base.Check_update_state();
        }

        protected override IRepository CreateNewRepository()
        {
            StateStoreDbContext context = new StateStoreDbContext(SqliteInMemory.CreateOptions<StateStoreDbContext>());
            context.Database.EnsureCreated();
            return new EfRepository<IDummyState, DummyState>(context, new Mock<IEventBus>().Object, new Mock<Logger<EfRepository<IDummyState, DummyState>>>().Object);
        }

        [Fact]
        protected override Task Save_state_throws_not_supported()
        {
            return base.Save_state_throws_not_supported();
        }

        [Fact]
        protected override Task Save_stream_throws_not_supported()
        {
            return base.Save_stream_throws_not_supported();
        }
    }
}