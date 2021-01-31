namespace Fiveforty.Queries
{
    using Fiveforty.Infrastructure;

    public record Query<TResult> : IQuery<TResult>
    {
        public string QueryId { get; } = UniqueId.Create();
    }
}