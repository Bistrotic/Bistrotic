namespace Bistrotic.Application.Queries
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    public abstract class Query<TResult> :
        Message, IQuery<TResult>
    {
    }

    public abstract class Query<TId, TResult> :
        Message<TId>, IQuery<TResult>
        where TId : BusinessId, new()
    {
        protected Query(TId id) : base(id)
        {
        }

        protected Query() : base(new TId())
        {
        }
    }
}