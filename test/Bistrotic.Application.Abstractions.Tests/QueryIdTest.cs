namespace Bistrotic.Application.Abstractions.Tests
{
    using Bistrotic.Application.ValueTypes;

    using FluentAssertions;

    using Xunit;

    public class QueryIdTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("            ")]
        public void QueryId_default_constructor(string value)
        {
            var messageId = new QueryId(value);
            messageId.Value.Should().NotBeNullOrWhiteSpace();
            messageId.Value.Should().HaveLength(22);
        }

        [Theory]
        [InlineData("L")]
        [InlineData("M@fd1523çççç\\\\èé")]
        [InlineData("AAAAAALLLLLLLLLLLLLLLLLLLLLLLLUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG")]
        [InlineData("        L")]
        [InlineData("L               ")]
        public void QueryId_string_constructor(string value)
        {
            var messageId = new QueryId(value);
            messageId.Value.Should().Be(value.Trim());
        }
    }
}