namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.EfCore.Helpers;

    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EfRepository<TIState, TState> : RepositoryBase<TIState>
        where TState : TIState, new()
    {
        private readonly StateStoreDbContext _context;

        public EfRepository(StateStoreDbContext context)
        {
            _context = context;
        }

        public override async Task<bool> Exists(string id, CancellationToken cancellationToken = default)
           => await _context
                .States
                .FindAsync(GetKey(id), cancellationToken)
                .ConfigureAwait(false) != null;

        public override async Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default)
            => await GetRecord(id, cancellationToken)
                .ConfigureAwait(false);

        public override async Task<TIState> GetState(string id, CancellationToken cancellationToken = default)
        {
            var value = (await GetRecord(id, cancellationToken)
                            .ConfigureAwait(false)
                        ).Value;
            if (value is TIState state)
            {
                return state;
            }
            throw new RepositoryStateDeserializeException(this, id);
        }

        public override Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default)
            => Task.FromException<IRepositoryStream>(new NotSupportedException($"The repository {GetType().Name} does not support event streams. Trying to retreive stream '{id}'."));

        public Task Save(string id, IRepositoryData stateData, CancellationToken cancellationToken = default)
            => Save(id, new RepositoryData<TState>(stateData), cancellationToken);

        private static object[] GetKey(string id)
        {
            var key = GetStateId(id);
            return new object[] { key.HashKey(), key };
        }

        private static string GetStateId(string id)
                    => typeof(TIState).Name + "@" + id;

        private async Task<State> GetRecord(string id, CancellationToken cancellationToken)
        {
            State? state = await _context
                .States
                .FindAsync(GetKey(id), cancellationToken)
                .ConfigureAwait(false);
            if (state == null)
                throw new RepositoryStateNotFoundException(this, id);
            return state;
        }

        public override Task Save(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);

        public override async Task SetState(string id, IRepositoryMetadata metadata, TIState state, CancellationToken cancellationToken = default)
        {
            if (state == null)
            {
                throw new RepositoryStateNullException(
                        this,
                        id, $"The state object given for saving Id='{id}' is null. Repository:'{GetType().Name}'.");
            }
            State data = await _context.States
                .FindAsync(GetKey(id), cancellationToken)
                .ConfigureAwait(false);
            if (data == null)
            {
                data = (State?)(new() { Id = GetStateId(id), CreatedByUser = metadata.UserName, CreatedUtcDateTime = DateTime.UtcNow });
                _context.States.Add(data);
            }
            else
            {
                data.LastModifiedByUser = metadata.UserName;
                data.LastModifiedUtcDateTime = DateTime.UtcNow;
            }
            data.Value = state;
        }

        public override async Task AddStateLog(string id, IRepositoryMetadata metadata, IEnumerable<object> events, CancellationToken cancellationToken = default)
        {
            int version = await GetStreamLatestVersion(id, cancellationToken).ConfigureAwait(false);
            _context.Add(events.ToEventStreamItem(id, metadata, version + 1));
        }

        private Task<int> GetStreamLatestVersion(string id, CancellationToken cancellationToken = default)
            => _context
            .EventStore
            .Where(p => p.IdHash == id.HashKey() && p.Id == id)
            .OrderByDescending(p => p.Version)
            .Select(p => p.Version)
            .FirstOrDefaultAsync(cancellationToken);

        public override Task Publish(IEnumerable<IEnvelope> events, CancellationToken cancellationToken = default)
        {
            foreach (var envelope in events)
            {
                _context.Add(envelope.ToOutboxMessage());
            }
            return Task.CompletedTask;
        }
        public async Task Save(string id, IRepositoryData<TIState> stateData, CancellationToken cancellationToken = default)
        {
            if (stateData.State == null)
            {
                throw new RepositoryStateNullException(
                        this,
                        id, $"The state object given for saving Id='{id}' is null. Repository:'{GetType().Name}'.");
            }
            State data = await _context.States
                .FindAsync(GetKey(id), cancellationToken)
                .ConfigureAwait(false);
            if (data == null)
            {
                data = (State?)(new() { Id = GetStateId(id), CreatedByUser = stateData.Metadata.UserName, CreatedUtcDateTime = DateTime.UtcNow });
                _context.States.Add(data);
            }
            else
            {
                data.LastModifiedByUser = stateData.Metadata.UserName;
                data.LastModifiedUtcDateTime = DateTime.UtcNow;
            }
            data.Value = stateData.State;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}