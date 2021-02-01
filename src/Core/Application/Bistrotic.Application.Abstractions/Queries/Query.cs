namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public record Query<TResult>(UserName UserName, BusinessId? Id = null) :
        Message(UserName, Id, null), IQuery<TResult>
    {
        public QueryId QueryId { get; } = new QueryId();
    }
}