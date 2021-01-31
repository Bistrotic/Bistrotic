namespace Bistrotic.Queries
{
    public record Query<TResult> : IQuery<TResult>
    {
        public QueryId QueryId { get; } = new QueryId();
    }
}