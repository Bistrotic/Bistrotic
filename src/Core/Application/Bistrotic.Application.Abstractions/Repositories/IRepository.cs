namespace Bistrotic.Application.Repositories
{
    using System;
    using System.Threading.Tasks;

    public interface IRepository
    {
        Task<object> CreateNew(Type dataType, string id);

        Task<bool> Exists(string id);

        Task<IRepositoryStateMetadata> GetMetadata(string id);

        Task<object> GetState(Type dataType, string id);

        Task<IRepositoryStream> GetStream(string id);

        Task Save(string id, IRepositoryData<object> stateData);
    }

    public interface IRepository<TState> : IRepository
    {
        Task<TState> CreateNew(string id);

        Task<TState> GetState(string id);

        Task Save(string id, IRepositoryData<TState> stateData);
    }
}