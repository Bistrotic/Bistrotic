namespace Bistrotic.Application.Queries
{
    using Bistrotic.Application.ValueTypes;
    using Bistrotic.Domain.Messages;

    public interface IQuery : IMessage
    {
        QueryId QueryId { get; }
    }

    public interface IQuery<TResult> : IQuery
    {
    }
}