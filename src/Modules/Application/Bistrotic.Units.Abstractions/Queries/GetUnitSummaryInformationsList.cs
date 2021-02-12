using Bistrotic.Application.Queries;
using Bistrotic.Units.Application.ModelViews;

namespace Bistrotic.Units.Application.Queries
{
    public sealed class GetUnitSummaryInformationsList
        : Query<UnitSummaryInformations[]>
    {
        public GetUnitSummaryInformationsList(int take = 0, int skip = 0)
        {
            Take = take;
            Skip = skip;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}