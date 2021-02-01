namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;

    public record Query<TResult> : IQuery<TResult>
    {
        public QueryId QueryId { get; } = new QueryId();
    }
}