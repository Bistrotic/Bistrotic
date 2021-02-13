namespace Bistrotic.Application.Queries
{
    using Bistrotic.Domain.Messages;

    public interface IQuery : IMessage
    {
    }

    public interface IQuery<TResult> : IQuery
    {
    }
}