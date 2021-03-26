namespace Bistrotic.Application.Abstractions.Tests.Fixture
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Domain.ValueTypes;

    public class TestCommandNoId : CommandBase
    {
    }

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

    public class TestIdCommand : Command<TestId>
    {
        public TestIdCommand()
        {
        }

        public TestIdCommand(TestId id) : base(id)
        {
        }
    }
}