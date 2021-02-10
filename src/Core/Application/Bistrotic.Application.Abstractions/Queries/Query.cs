namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public record Query<TResult>(string Domain, BusinessId? Id = null) :
        Message(Domain, Id, null), IQuery<TResult>
    {
        public QueryId QueryId { get; } = new QueryId();
    }
}