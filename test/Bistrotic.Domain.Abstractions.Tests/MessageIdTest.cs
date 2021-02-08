namespace Bistrotic.Domain.Abstractions.Tests
{
    using Bistrotic.Domain.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class MessageIdTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("            ")]
        public void MessageId_default_constructor(string value)
        {
            var messageId = new MessageId(value);
            messageId.Value.Should().NotBeNullOrWhiteSpace();
            messageId.Value.Should().HaveLength(22);
        }

        [Theory]
        [InlineData("L")]
        [InlineData("M@fd1523çççç\\\\èé")]
        [InlineData("AAAAAALLLLLLLLLLLLLLLLLLLLLLLLUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG")]
        [InlineData("        L")]
        [InlineData("L               ")]
        public void MessageId_string_constructor(string value)
        {
            var messageId = new MessageId(value);
            messageId.Value.Should().Be(value.Trim());
        }
    }
}