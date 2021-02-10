using Bistrotic.Application.Queries;
using Bistrotic.Units.Application.ModelViews;
using Bistrotic.Units.Domain;

namespace Bistrotic.Units.Application.Queries
{
    public record GetUnitSummaryInformationsList(int Take = 0, int Skip = 0)
        : Query<UnitSummaryInformations[]>(UnitConstants.DomainName)
    {
    }
}