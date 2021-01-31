namespace Fiveforty.Module.Units
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fiveforty.Module.Units.ModelViews;
    using Fiveforty.Queries;

    public interface IUnitQueryService : IQueryService
    {
        Task<List<string>> GetAllIds(int take = 0, int skip = 0);

        Task<int> GetCount();

        Task<UnitDetailedInformations> GetDetailedInformations(string unitId);

        Task<List<UnitSummaryInformations>> GetSearchMatching(string pattern, int take = 0, int skip = 0);

        Task<UnitSummaryInformations> GetSummaryInformations(string unitId);

        Task<List<UnitSummaryInformations>> GetSummaryInformationsList(int take = 0, int skip = 0);
    }
}