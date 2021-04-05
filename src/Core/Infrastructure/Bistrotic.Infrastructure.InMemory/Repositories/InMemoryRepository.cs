using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Exceptions;
using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryRepository<TIState, TState> : RepositoryBase<TIState>
        where TState : TIState, new()
    {
        private readonly Dictionary<string, (TIState, IRepositoryStateMetadata)> _data = new();

        public override Task<bool> Exists(string id, CancellationToken cancellationToken = default) => Task.FromResult(_data.ContainsKey(id));

        public override Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default)
        {
            (_, IRepositoryStateMetadata metadata) = GetById(id);
            return Task.FromResult(metadata);
        }

        public override Task<TIState> GetState(string id, CancellationToken cancellationToken = default)
        {
            (TIState state, _) = GetById(id);
            return Task.FromResult(state);
        }

        public override Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default)
            => Task.FromException<IRepositoryStream>(new NotSupportedException($"The '{GetType().Name}' repository does not support streams."));

        public override Task Save(string id, IRepositoryData<TIState> stateData, CancellationToken cancellationToken = default)
        {
            if (stateData.State == null)
            {
                if (stateData.Events != null)
                {
                    throw new NotSupportedException($"You must give a state to save. This repository ({GetType().Name}) does not support streams.");
                }
                throw new ArgumentNullException(nameof(stateData), $"You must give a state to save. Repository : '{GetType().Name}'.");
            }
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

        private (TIState state, IRepositoryStateMetadata metadata) GetById(string id)
        {
            if (!_data.TryGetValue(id, out (TIState, IRepositoryStateMetadata) data))
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TIState)}';Id='{id}') not found.");
            }
            return data;
        }
    }
}