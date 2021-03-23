using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryStreamRepository<TState> : IRepository<TState>
        where TState : IEventDrivenState, new()
    {
        private readonly Dictionary<string, Dictionary<long, RepositoryData<TState>>> _data = new();

        public Task<bool> Exists(string id) => Task.FromResult(_data.ContainsKey(id));

        public Task<TState> GetData(string id)
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

        public Task Save(string id, RepositoryData<TState> state)
        {
            Dictionary<long, RepositoryData<TState>>? stream
                = _data[id] ??= new Dictionary<long, RepositoryData<TState>>();
            stream.Add(stream.Keys.Max() + 1, state);
            _data[id] = stream;
            return Task.CompletedTask;
        }
    }
}