namespace Bistrotic.Application.Abstractions.Tests.Fixture
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Domain.ValueTypes;

    public class TestCommandNoId : Command
    {
    }

    public class TestIdCommand : Command<TestId>
    {
        public TestIdCommand(TestId id) : base(id)
        {
        }
    }

    public sealed record TestId : BusinessId
    {
        public TestId(string id) : base(id)
        {
        }
    }
}