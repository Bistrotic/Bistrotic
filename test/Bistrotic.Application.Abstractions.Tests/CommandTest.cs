namespace Bistrotic.Application.Abstractions.Tests
{
    using Bistrotic.Application.Abstractions.Tests.Fixture;

    using FluentAssertions;

    using Xunit;

    public class CommandTest
    {
        [Theory]
        [InlineData("L")]
        [InlineData("M@fd1523çççç\\\\èé")]
        [InlineData("AAAAAALLLLLLLLLLLLLLLLLLLLLLLLUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG")]
        [InlineData("        L")]
        [InlineData("L               ")]
        public void CommandId_string_constructor(string value)
        {
            var message = new TestIdCommand(new TestId(value));
            message.TestId.Should().Be(value.Trim());
        }
    }
}