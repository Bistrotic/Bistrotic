using System;
using System.Threading.Tasks;

using Bistrotic.Application.Exceptions;

namespace Bistrotic.Application.Repositories
{
    public abstract class RepositoryBase<TState> : IRepository<TState>
    {
        public abstract Task<bool> Exists(string id);

        public abstract Task<IRepositoryStateMetadata> GetMetadata(string id);

        public abstract Task<TState?> GetState(string id);

        public abstract Task<IRepositoryStream> GetStream(string id);

        public abstract Task Save(string id, IRepositoryData<TState> stateData);

        async Task<object> IRepository.GetState(Type dataType, string id)
            => await GetState(id).ConfigureAwait(false) ??
                throw new RepositoryReadFailedException(id, GetType().Name);

        Task IRepository.Save(string id, IRepositoryData<object> stateData)
            => Save(id, (IRepositoryData<TState>)stateData);
    }
}