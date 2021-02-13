namespace Bistrotic.Domain.Abstractions.Tests
{
    using System.Text.Json;

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
        public void MessageId_serialize_to_string(string value)
        {
            var messageId = new MessageId(value);
            messageId.Value.Should().Be(value.Trim());
            var serialized = JsonSerializer.Serialize(messageId);
            serialized.Should().Be(JsonSerializer.Serialize(value.Trim()));
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