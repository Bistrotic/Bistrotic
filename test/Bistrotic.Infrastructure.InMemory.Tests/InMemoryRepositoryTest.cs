namespace Bistrotic.Infrastructure.InMemory.Tests
{
    using System;

    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.InMemory.Repositories;
    using Bistrotic.Infrastructure.InMemory.Tests.Fixtures;

    using Xunit;

    public class InMemoryRepositoryTest
    {
        [Fact]
        public void Test1(object anEvent)
        {
            var state1 = new DummyState() { Value1 = true, Value2 = 10, Value3 = "Hello" };
            var state2 = new DummyState() { Value1 = false, Value2 = 99, Value3 = "Cake" };
            var state3 = new DummyState() { Value1 = true, Value2 = 1010, Value3 = "Sunday" };
            var state4 = new DummyState() { Value1 = false, Value2 = 10900, Value3 = "June" };
            var repository = new InMemoryRepository<DummyState>();
            repository.Save(nameof(state1), new RepositoryData<DummyState>(
                correlationId = "cor1", causationId = "cause1", "harold", DateTimeOffset.Now, null)
                ))
        }
    }
}