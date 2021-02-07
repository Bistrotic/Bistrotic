namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;

    public interface IQuery
    {
        QueryId QueryId { get; }
    }

    public interface IQuery<TResult> : IQuery
    {
    }
}