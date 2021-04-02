namespace Bistrotic.Application.Abstractions.Tests.Fixture
{
    using Bistrotic.Domain.ValueTypes;

    public sealed class TestId : BusinessId
    {
        public TestId()
        {
        }

        public TestId(string id) : base(id)
        {
        }

        public TestId(TestId id) : base(id)
        {
        }

        public static implicit operator TestId(string value) => new TestId(value);
    }

    public class TestIdCommand
    {
        public TestIdCommand()
        {
        }

        public TestIdCommand(TestId testId)
        {
            TestId = testId;
        }

        public string TestId { get; }
    }
}