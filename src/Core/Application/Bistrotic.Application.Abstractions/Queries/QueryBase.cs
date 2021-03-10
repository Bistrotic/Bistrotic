namespace Bistrotic.Application.Queries
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public abstract class QueryBase<TResult> :
        Message, IQuery<TResult>
    {
    }

    public abstract class QueryBase<TId, TResult> :
        MessageBase<TId>, IQuery<TResult>
        where TId : BusinessId, new()
    {
        protected QueryBase(TId id) : base(id)
        {
        }

        protected QueryBase() : base(new TId())
        {
        }
    }
}