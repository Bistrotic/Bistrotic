namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.EfCore.Helpers;

    public class StateStoreRepository<TIState, TState>
        : IRepository<TIState>
        where TState : TIState, new()
    {
        private readonly StateStoreDbContext _context;

        public StateStoreRepository(StateStoreDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(string id, CancellationToken cancellationToken = default)
           => await _context
                .States
                .FindAsync(GetKey(id), cancellationToken)
                .ConfigureAwait(false) != null;

        public async Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default)
            => await GetRecord(id, cancellationToken)
                .ConfigureAwait(false);

        public async Task<TIState> GetState(string id, CancellationToken cancellationToken = default)
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

        public async Task<object> GetState(Type dataType, string id, CancellationToken cancellationToken = default)
            => await GetState(id, cancellationToken)
                .ConfigureAwait(false)
                    ?? throw new RepositoryStateNotFoundException(this, id);

        public Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default)
            => Task.FromException<IRepositoryStream>(new NotSupportedException($"The repository {GetType().Name} does not support event streams. Trying to retreive stream '{id}'."));

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
            => await _context
                .States
                .FindAsync(GetKey(id), cancellationToken)
                .ConfigureAwait(false)
                    ?? throw new RepositoryStateNotFoundException(this, id);
    }
}