using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bistrotic.Application.Repositories;

namespace Bistrotic.Infrastructure.InMemory.Repositories
{
    public class InMemoryStreamRepository<TState> : RepositoryBase<TState>
        where TState : IEventDrivenState, new()
    {
        private readonly Dictionary<string, IRepositoryStream> _data = new();

        public override Task<bool> Exists(string id) => Task.FromResult(_data.ContainsKey(id));

        public override Task<IRepositoryStateMetadata> GetMetadata(string id)
        {
            var data = GetById(id);
            var creator = data.First();
            var metadata = new RepositoryStateMetadata()
            {
                CreatedByUser = creator.Value.metadata.UserName,
                CreatedUtcDateTime = creator.Value.metadata.SystemUtcDateTime
            };
            if (data.Count > 1)
            {
                var last = data.Last();
                metadata.LastModifiedByUser = last.Value.metadata.UserName;
                metadata.LastModifiedUtcDateTime = last.Value.metadata.SystemUtcDateTime;
            }
            return Task.FromResult<IRepositoryStateMetadata>(metadata);
        }

        public override Task<TState> GetState(string id)
        {
            TState state = new();
            foreach (var stateData in GetById(id))
            {
                state.Apply(stateData.Value.events);
            }
            return Task.FromResult(state);
        }

        public override Task<IRepositoryStream> GetStream(string id)
            => Task.FromResult(GetById(id));

        public override Task Save(string id, IRepositoryData<TState> stateData)
        {
            if (!stateData.Events.Any())
            {
                throw new MissingEventsException<InMemoryStreamRepository<TState>>(id);
            }
            IRepositoryStream? stream
                = _data[id] ??= new RepositoryStream();
            stream.Add(stream.Keys.Max() + 1, stateData);
            _data[id] = stream;
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