namespace Bistrotic.UblInvoices.Application
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUblIntegrationRepository
    {
        public IQueryable<UblIntegration> Integrations { get; }

        public Task Add(UblIntegration integration);

        public Task Save();
    }
}
