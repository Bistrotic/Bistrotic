namespace Fiveforty.Domain
{
    using Fiveforty.Domain.Messages;

    public interface IRepository<TState>
        where TState : class, IEntityState, new()
    {
        TState? Find(string id);

        TState Get(string id);

        void Remove(string id);

        void Save(IEvent @event, TState entityState);
    }
}