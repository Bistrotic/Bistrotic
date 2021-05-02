using Bistrotic.Application.Messages;
using Bistrotic.Application.Repositories;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryRepository<TIState, TState> : RepositoryBase<TIState>
        where TState : TIState, new()
    {
        private readonly Dictionary<string, (TIState, IRepositoryStateMetadata)> _states = new();
        private readonly Dictionary<string, List<(IEnumerable<object>, IRepositoryStateMetadata)>> _streams = new();
        private readonly List<IEnvelope> _outbox = new();

        public override Task<bool> Exists(string id, CancellationToken cancellationToken = default) => Task.FromResult(_states.ContainsKey(id));

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

        private (TIState state, IRepositoryStateMetadata metadata) GetById(string id)
        {
            if (!_states.TryGetValue(id, out (TIState, IRepositoryStateMetadata) data))
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TIState)}';Id='{id}') not found.");
            }
            return data;
        }

        public override Task Save(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public override Task SetState(string id, IRepositoryMetadata metadata, TIState state, CancellationToken cancellationToken = default)
        {
            if (!_states.ContainsKey(id))
            {
                _states[id] = (state, new RepositoryStateMetadata()
                {
                    CreatedByUser = metadata.UserName,
                    CreatedUtcDateTime = metadata.SystemUtcDateTime
                });
            }
            else
            {
                (_, IRepositoryStateMetadata m) = GetById(id);
                m.LastModifiedByUser = metadata.UserName;
                m.LastModifiedUtcDateTime = metadata.SystemUtcDateTime;
                _states[id] = (state, m);
            }
            return Task.CompletedTask;
        }

        public override Task AddStateLog(string id, IRepositoryMetadata metadata, IEnumerable<object> events, CancellationToken cancellationToken = default)
        {
            if (!_streams.ContainsKey(id))
            {
                _streams[id] = new()
                {
                    (events, new RepositoryStateMetadata()
                    {
                        CreatedByUser = metadata.UserName,
                        CreatedUtcDateTime = metadata.SystemUtcDateTime
                    })
                };
            }
            else
            {
                (_, IRepositoryStateMetadata m) = GetById(id);
                m.LastModifiedByUser = metadata.UserName;
                m.LastModifiedUtcDateTime = metadata.SystemUtcDateTime;
                _streams[id].Add((events, m));
            }
            return Task.CompletedTask;
        }

        public override Task Publish(IEnumerable<IEnvelope> events, CancellationToken cancellationToken = default)
        {
            _outbox.AddRange(events);
            return Task.CompletedTask;
        }
    }
}