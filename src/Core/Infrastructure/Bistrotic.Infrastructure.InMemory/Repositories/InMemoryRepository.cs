using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryRepository<TState> : RepositoryBase<TState>
    {
        private readonly Dictionary<string, (TState, IRepositoryStateMetadata)> _data = new();

        public override Task<bool> Exists(string id) => Task.FromResult(_data.ContainsKey(id));

        public override Task<IRepositoryMetadata<TState>> GetData(string id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<TState> GetState(string id)
        {
            var data = _data[id];
            if (data == null)
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TState)}';Id='{id}')");
            }
            return Task.FromResult(data.State);
        }

        public override Task Save(string id, IRepositoryMetadata<TState> stateData)
        {
            _data[id] = stateData;
            return Task.CompletedTask;
        }
    }
}