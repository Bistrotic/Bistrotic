using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Exceptions;
using Bistrotic.Application.Repositories;
using Bistrotic.Infrastructure.InMemory.Exceptions;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryStreamRepository<TState> : RepositoryBase<TState>
        where TState : IEventDrivenState, new()
    {
        private readonly Dictionary<string, IRepositoryStream> _data = new();

        public override Task<bool> Exists(string id, CancellationToken cancellationToken = default) => Task.FromResult(_data.ContainsKey(id));

        public override Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default)
        {
            var stream = GetById(id);
            var creator = stream.Read(1);
            var metadata = new RepositoryStateMetadata()
            {
                CreatedByUser = creator.metadata.UserName,
                CreatedUtcDateTime = creator.metadata.SystemUtcDateTime
            };
            if (stream.Position > 1)
            {
                var last = stream.Read(stream.Position);
                metadata.LastModifiedByUser = last.metadata.UserName;
                metadata.LastModifiedUtcDateTime = last.metadata.SystemUtcDateTime;
            }
            return Task.FromResult<IRepositoryStateMetadata>(metadata);
        }

        public override Task<TState> GetState(string id, CancellationToken cancellationToken = default)
        {
            TState state = new();
            var stream = GetById(id);
            for (int i = 1; i <= stream.Position; i++)
            {
                state.Apply(stream.Read(i).events);
            }
            return Task.FromResult(state);
        }

        public override Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default)
            => Task.FromResult(GetById(id));

        public override Task Save(string id, IRepositoryData<TState> stateData, CancellationToken cancellationToken = default)
        {
            if (!stateData.Events.Any())
            {
                if (stateData.State != null)
                {
                    throw new NotSupportedException($"The '{GetType().Name}' repository only supports streams of events. It cannot save states.");
                }
                throw new MissingEventsException<InMemoryStreamRepository<TState>>(id);
            }
            if (!_data.TryGetValue(id, out IRepositoryStream? stream))
            {
                stream = new InMemoryRepositoryStream();
                _data[id] = stream;
            }
            stream.Add(stateData.Metadata, stateData.Events);
            return Task.CompletedTask;
        }

        private IRepositoryStream GetById(string id)
        {
            if (!_data.TryGetValue(id, out IRepositoryStream? data))
            {
                throw new KeyNotFoundException($"The storage object (Type='{typeof(TState)}';Id='{id}') not found.");
            }
            return data;
        }
    }
}