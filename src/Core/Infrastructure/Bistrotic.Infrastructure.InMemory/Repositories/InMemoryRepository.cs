using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryRepository<TState> : RepositoryBase<TState>
    {
        private readonly Dictionary<string, (TState, IRepositoryStateMetadata)> _data = new();

        public override Task<bool> Exists(string id) => Task.FromResult(_data.ContainsKey(id));

        public override Task<IRepositoryStateMetadata> GetMetadata(string id)
        {
            (_, IRepositoryStateMetadata metadata) = GetById(id);
            return Task.FromResult(metadata);
        }

        public override Task<TState> GetState(string id)
        {
            (TState state, _) = GetById(id);
            return Task.FromResult(state);
        }

        public override Task<IRepositoryStream> GetStream(string id)
            => Task.FromException<IRepositoryStream>(new NotSupportedException($"The '{GetType().Name}' repository does not support streams."));

        public override Task Save(string id, IRepositoryData<TState> stateData)
        {
            if (!_data.ContainsKey(id))
            {
                _data[id] = (stateData.State, new RepositoryStateMetadata()
                {
                    CreatedByUser = stateData.Metadata.UserName,
                    CreatedUtcDateTime = DateTime.UtcNow
                });
            }
            else
            {
                (_, IRepositoryStateMetadata metadata) = GetById(id);
                metadata.LastModifiedByUser = stateData.Metadata.UserName;
                metadata.LastModifiedUtcDateTime = DateTime.UtcNow;
                _data[id] = (stateData.State, metadata);
            }
            return Task.CompletedTask;
        }

        private (TState state, IRepositoryStateMetadata metadata) GetById(string id)
        {
            if (!_data.TryGetValue(id, out (TState, IRepositoryStateMetadata) data))
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TState)}';Id='{id}') not found.");
            }
            return data;
        }
    }
}