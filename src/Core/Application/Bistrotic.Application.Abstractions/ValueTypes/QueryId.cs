namespace Bistrotic.Application.ValueTypes
{
    using Bistrotic.Domain.ValueTypes;

    public record QueryId : MessageId
    {
        public QueryId(QueryId queryId) : base(queryId)
        {
        }
        public QueryId(string? queryId = null) : base(queryId)
        {
        }
    }
}