namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    public interface IRepositoryDbSet
    {
        public string Id { get; }
        public int IdHash { get; }
    }
}