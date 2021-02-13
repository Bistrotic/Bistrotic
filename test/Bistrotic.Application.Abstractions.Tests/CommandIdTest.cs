namespace Bistrotic.Application.Abstractions.Tests
{
    using FluentAssertions;

    using Xunit;

    public class CommandIdTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("            ")]
        public void CommandId_default_constructor(string value)
        {
            var messageId = new CommandId(value);
            messageId.Value.Should().NotBeNullOrWhiteSpace();
            messageId.Value.Should().HaveLength(22);
        }

        [Theory]
        [InlineData("L")]
        [InlineData("M@fd1523çççç\\\\èé")]
        [InlineData("AAAAAALLLLLLLLLLLLLLLLLLLLLLLLUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG")]
        [InlineData("        L")]
        [InlineData("L               ")]
        public void CommandId_string_constructor(string value)
        {
            var messageId = new CommandId(value);
            messageId.Value.Should().Be(value.Trim());
        }
    }
}