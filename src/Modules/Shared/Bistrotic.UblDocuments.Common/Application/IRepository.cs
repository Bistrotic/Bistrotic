namespace Bistrotic.UblDocuments.Application
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository
    {
        public Task Save(CancellationToken cancellationToken = default);
        public IQueryable<T> GetSet<T>() where T : class;
        public void Add<T>(T record);
    }
}
