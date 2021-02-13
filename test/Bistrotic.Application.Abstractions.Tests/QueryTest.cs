namespace Bistrotic.Application.Abstractions.Tests
{
    using Bistrotic.Application.Abstractions.Tests.Fixture;

    using FluentAssertions;

    using Xunit;

    public class QueryTest
    {
        [Fact]
        public void Query_default_constructor()
        {
            var message = new TestQueryNoId();
            message.MessageId.Value.Should().NotBeNullOrWhiteSpace();
            message.MessageId.Value.Should().HaveLength(22);
            message.Id?.Value.Should().BeNull();
        }

        [Theory]
        [InlineData("L")]
        [InlineData("M@fd1523çççç\\\\èé")]
        [InlineData("AAAAAALLLLLLLLLLLLLLLLLLLLLLLLUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG")]
        [InlineData("        L")]
        [InlineData("L               ")]
        public void QueryId_string_constructor(string value)
        {
            var message = new TestIdQuery(new TestId(value));
            message.MessageId.Value.Should().NotBeNullOrWhiteSpace();
            message.MessageId.Value.Should().HaveLength(22);
            message.Id.Value.Should().Be(value.Trim());
        }
    }
}