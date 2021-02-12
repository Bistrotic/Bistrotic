namespace Bistrotic.Application.Tests
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.Application.Tests.Fixture;
    using Bistrotic.Domain.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class InMemoryQueryDispatcherTest
    {
        [Fact]
        public async Task Dispatch_check_return_values()
        {
            var dispatcher = new InMemoryQueryDispatcher(new Handlers());
            (await dispatcher.Dispatch<Query1, int>(new Query1()).ConfigureAwait(false))
                .Should().Be(1);
            (await dispatcher.Dispatch<Query2, string>(new Query2()).ConfigureAwait(false))
                .Should().Be("2");
            (await dispatcher.Dispatch<Query3, Guid>(new Query3()).ConfigureAwait(false))
                .Should().Be(new Guid("3"));
            var query = new Query4();
            (await dispatcher.Dispatch<Query4, MessageId>(query).ConfigureAwait(false))
                .Should().Be(query.MessageId);
        }
    }
}