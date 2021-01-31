namespace Bistrotic.Queries
{
    public interface IQuery<TResult>
    {
        QueryId QueryId { get; }
    }
}