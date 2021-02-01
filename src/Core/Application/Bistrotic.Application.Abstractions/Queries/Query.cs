namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public record Query<TResult>(BusinessId? Id = null) :
        Message(Id, null), IQuery<TResult>
    {
        public QueryId QueryId { get; } = new QueryId();
    }
}