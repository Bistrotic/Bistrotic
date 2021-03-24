using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryStreamRepository<TState> : RepositoryBase<TState>
        where TState : IEventDrivenState, new()
    {
        private readonly Dictionary<string, Dictionary<long, IRepositoryMetadata<TState>>> _data = new();

        public override Task<bool> Exists(string id) => Task.FromResult(_data.ContainsKey(id));

        public override Task<IRepositoryMetadata<TState>> GetData(string id)
        {
            var data = _data[id];
            if (data == null)
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TState)}';Id='{id}')");
            }
            TState state = new();
            foreach (var stateData in data.Values)
            {
                state.Apply(stateData.Events);
            }
            return Task.FromResult(state);
        }

        public override Task<TState> GetState(string id)
        {
            var data = _data[id];
            if (data == null)
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TState)}';Id='{id}')");
            }
            TState state = new();
            foreach (var stateData in data.Values)
            {
                state.Apply(stateData.Events);
            }
            return Task.FromResult(state);
        }

        public override Task Save(string id, IRepositoryMetadata<TState> stateData)
        {
            if (!stateData.Events.Any())
            {
                throw new MissingEventsException<InMemoryStreamRepository<TState>>(id);
            }
            Dictionary<long, IRepositoryMetadata<TState>>? stream
                = _data[id] ??= new Dictionary<long, IRepositoryMetadata<TState>>();
            stream.Add(stream.Keys.Max() + 1, stateData);
            _data[id] = stream;
            return Task.CompletedTask;
        }
    }
}