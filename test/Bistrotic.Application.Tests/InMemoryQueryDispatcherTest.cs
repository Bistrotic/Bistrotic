namespace Bistrotic.Application.Tests
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Application.Tests.Fixture;
    using Bistrotic.Domain.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class InMemoryQueryDispatcherTest
    {
        [Fact]
        public async Task Dispatch_query_check_return_values()
        {
            var dispatcher = new InMemoryQueryDispatcher(new QueryHandlers());
            (await dispatcher.Dispatch<Query1, int>(
                    new Envelope<Query1>(new Query1(), new UserName("User 1"))
                    ).ConfigureAwait(false))
                .Should().Be(1);
            (await dispatcher.Dispatch<Query2, string>(
                    new Envelope<Query2>(new Query2(), new UserName("User 2"))
                    ).ConfigureAwait(false))
                .Should().Be("2");
            (await dispatcher.Dispatch<Query3, Guid>(new Envelope<Query3>(new Query3(), new UserName("User 3"))
                ).ConfigureAwait(false))
                .Should().Be(new Guid("66CABB1C-18E3-4E26-AE0F-EA603D9F11FB"));
            var query = new Envelope<Query4>(new Query4(), new UserName("User 4"));
            (await dispatcher.Dispatch<Query4, string>(query).ConfigureAwait(false))
                .Should().Be(query.Message.MessageId);
        }
    }
}