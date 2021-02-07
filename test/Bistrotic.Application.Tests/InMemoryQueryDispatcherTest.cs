namespace Bistrotic.Application.Tests
{
    using System;

    using Bistrotic.Application.Queries;
    using Bistrotic.Application.Tests.Fixture;
    using Bistrotic.Application.ValueTypes;

    using Xunit;
    using FluentAssertions;

    public class InMemoryQueryDispatcherTest
    {
        [Fact]
        public async void Dispatch_check_return_values()
        {
            var dispatcher = new InMemoryQueryDispatcher(new Handlers());
            (await dispatcher.Dispatch<Query1, int>(new Query1()))
                .Should().Be(1);
            (await dispatcher.Dispatch<Query2, string>(new Query2()))
                .Should().Be("2");
            (await dispatcher.Dispatch<Query3, Guid>(new Query3()))
                .Should().Be(new Guid("3"));
            var query = new Query4();
            (await dispatcher.Dispatch<Query4, QueryId>(query))
                .Should().Be(query.QueryId);
        }
    }
}