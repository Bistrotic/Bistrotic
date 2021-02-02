using Bistrotic.Application.Queries;
using Bistrotic.Units.Application.ModelViews;

namespace Bistrotic.Units.Application.Queries
{
    public record GetUnitSummaryInformationsList(int Take = 0, int Skip = 0) : Query<UnitSummaryInformations[]>
    {
    }
}