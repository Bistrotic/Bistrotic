using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryRepository<State> : IRepository<State>
    {
        private readonly Dictionary<string, RepositoryData<State>> _data = new();

        public Task<bool> Exists(string id) => Task.FromResult(_data.ContainsKey(id));

        public Task<State> GetData(string id)
        {
            var data = _data[id];
            if (data == null)
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(State)}';Id='{id}')");
            }
            return Task.FromResult(data.State);
        }

        public Task Save(string id, RepositoryData<State> state)
        {
            _data[id] = state;
            return Task.CompletedTask;
        }
    }
}