namespace Bistrotic.Application.Repositories
{
    using System.Threading.Tasks;

    public interface IRepository<TState>
    {
        Task<bool> Exists(string id);

        Task<TState> GetData(string id);

        Task Save(string id, RepositoryData<TState> state);
    }
}