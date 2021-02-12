namespace Bistrotic.Domain.Messages
{
    using Bistrotic.Domain.ValueTypes;

    public abstract class Event : Message, IEvent
    {
    }

    public abstract class Event<TId> : Message<TId>, IEvent
        where TId : BusinessId
    {
        protected Event(TId id) : base(id)
        {
        }
    }
}