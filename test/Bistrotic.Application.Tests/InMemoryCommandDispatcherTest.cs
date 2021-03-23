namespace Bistrotic.Application.Tests
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Tests.Fixture;
    using Bistrotic.Domain.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class InMemoryCommandDispatcherTest
    {
        [Fact]
        public async Task Dispatch_command()
        {
            var commandHandlers = new CommandHandlers();
            var dispatcher = new InMemoryCommandDispatcher(commandHandlers);
            await dispatcher
                .Dispatch(new Envelope<Command1>(new Command1(), new MessageId(), new UserName("User 1"), DateTimeOffset.Now));
            await dispatcher
                .Dispatch(new Envelope<Command2>(new Command2(), new MessageId(), new UserName("User 2"), DateTimeOffset.Now));
            await dispatcher
                .Dispatch(new Envelope<Command3>(new Command3(), new MessageId(), new UserName("User 3"), DateTimeOffset.Now));
            await dispatcher
                .Dispatch(new Envelope<Command4>(new Command4(), new MessageId(), new UserName("User 4"), DateTimeOffset.Now));

            foreach (var pair in commandHandlers)
            {
                pair.Value.Should().NotBeNull();
            }
        }
    }
}