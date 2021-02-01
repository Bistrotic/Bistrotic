namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;

    public interface IQuery<TResult>
    {
        QueryId QueryId { get; }
    }
}