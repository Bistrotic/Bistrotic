namespace Bistrotic.UblInvoices.Application
{
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.UblDocuments.Types.Entities;

    public interface ICountryRepository
    {
        public IQueryable<Country> Countries { get; }


        public Task Add(Country country);

        public Task Save();
    }
}
