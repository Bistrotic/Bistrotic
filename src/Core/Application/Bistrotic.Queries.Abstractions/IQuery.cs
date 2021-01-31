namespace Fiveforty.Queries
{
    public interface IQuery<TResult>
    {
        string QueryId { get; }
    }
}