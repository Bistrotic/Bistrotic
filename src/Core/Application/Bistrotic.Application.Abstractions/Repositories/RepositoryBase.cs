using System;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Exceptions;

namespace Bistrotic.Application.Repositories
{
    public abstract class RepositoryBase<TState> : IRepository<TState>
    {
        public abstract Task<TState> CreateNew(string id, CancellationToken cancellationToken = default);

        public abstract Task<bool> Exists(string id, CancellationToken cancellationToken = default);

        public abstract Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default);

        public abstract Task<TState> GetState(string id, CancellationToken cancellationToken = default);

        public abstract Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default);

        public abstract Task Save(string id, IRepositoryData<TState> stateData, CancellationToken cancellationToken = default);

        async Task<object> IRepository.CreateNew(Type dataType, string id, CancellationToken cancellationToken)
            => await CreateNew(id, cancellationToken).ConfigureAwait(false) ??
                throw new RepositoryStateNullException(this, id, GetType().Name);

        async Task<object> IRepository.GetState(Type dataType, string id, CancellationToken cancellationToken)
                    => await GetState(id, cancellationToken).ConfigureAwait(false) ??
                throw new RepositoryStateNullException(this, id, GetType().Name);

        Task IRepository.Save(string id, IRepositoryData stateData, CancellationToken cancellationToken)
            => Save(id, (IRepositoryData<TState>)stateData, cancellationToken);
    }
}