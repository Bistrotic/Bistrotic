namespace Bistrotic.Infrastructure.InMemory.Tests
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.InMemory.Repositories;
    using Bistrotic.Infrastructure.InMemory.Tests.Fixtures;

    using FluentAssertions;

    using Xunit;

    public class InMemoryRepositoryTest
    {
        [Fact]
        public async Task Save_then_getdata_should_retreive_equal_values()
        {
            var state1 = new DummyState() { Value1 = true, Value2 = 10, Value3 = "Hello" };
            var state2 = new DummyState() { Value1 = false, Value2 = 99, Value3 = "Cake" };
            var state3 = new DummyState() { Value1 = true, Value2 = 1010, Value3 = "Sunday" };
            var state4 = new DummyState() { Value1 = false, Value2 = 10900, Value3 = "June" };
            var repository = new InMemoryRepository<DummyState>();
            await repository.Save(
                nameof(state1),
                new RepositoryData<DummyState>("cor1", "cause1", "harold", DateTimeOffset.Now, state1)
                );
            await repository.Save(
                nameof(state1),
                new RepositoryData<DummyState>("cor2", "cause2", "jean", DateTimeOffset.Now, state2)
                );
            await repository.Save(
                nameof(state1),
                new RepositoryData<DummyState>("cor3", "cause3", "michel", DateTimeOffset.Now, state3)
                );
            await repository.Save(
                nameof(state1),
                new RepositoryData<DummyState>("cor4", "cause4", "pierre", DateTimeOffset.Now, state4)
                );
            var state = await repository.GetData(nameof(state3));
            state.Value1.Should().Be(state3.Value1);
            state.Value2.Should().Be(state3.Value2);
            state.Value3.Should().Be(state3.Value3);
        }
    }
}