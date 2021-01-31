namespace Fiveforty.Infrastructure
{
    using System.Threading.Tasks;

    public interface IRepository<TState>
    {
        Task<RepositoryData<TState>> GetData(string id);

        Task Save(string id, RepositoryData<TState> state);
    }
}