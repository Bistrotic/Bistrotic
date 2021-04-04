namespace Bistrotic.Application.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository
    {
        Task<object> CreateNew(Type dataType, string id, CancellationToken cancellationToken = default);

        Task<bool> Exists(string id, CancellationToken cancellationToken = default);

        Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default);

        Task<object> GetState(Type dataType, string id, CancellationToken cancellationToken = default);

        Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default);

        Task Save(string id, IRepositoryData stateData, CancellationToken cancellationToken = default);
    }

    public interface IRepository<TState> : IRepository
    {
        Task<TState> CreateNew(string id, CancellationToken cancellationToken = default);

        Task<TState> GetState(string id, CancellationToken cancellationToken = default);

        Task Save(string id, IRepositoryData<TState> stateData, CancellationToken cancellationToken = default);
    }
}