namespace Bistrotic.Application.Abstractions.Tests
{
    using Bistrotic.Application.Abstractions.Tests.Fixture;

    using FluentAssertions;

    using Xunit;

    public class CommandTest
    {
        [Fact]
        public void Command_default_constructor()
        {
            var message = new TestCommandNoId();
            message.MessageId.Value.Should().NotBeNullOrWhiteSpace();
            message.MessageId.Value.Should().HaveLength(22);
            message.Id?.Should().BeNull();
        }

        [Theory]
        [InlineData("L")]
        [InlineData("M@fd1523çççç\\\\èé")]
        [InlineData("AAAAAALLLLLLLLLLLLLLLLLLLLLLLLUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG")]
        [InlineData("        L")]
        [InlineData("L               ")]
        public void CommandId_string_constructor(string value)
        {
            var message = new TestIdCommand(new TestId(value));
            message.MessageId.Value.Should().NotBeNullOrWhiteSpace();
            message.MessageId.Value.Should().HaveLength(22);
            message.Id.Should().Be(value.Trim());
        }
    }
}