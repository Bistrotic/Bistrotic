namespace Bistrotic.Application.Abstractions.Tests.Fixture
{
    using Bistrotic.Application.Queries;

    public class TestIdQuery : Query<TestId, int>
    {
        public TestIdQuery(TestId id) : base(id)
        {
        }
    }

    public class TestQueryNoId : Query<string>
    {
    }
}