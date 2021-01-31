namespace Fiveforty.Module.Units.Queries
{
    using System.Collections.Generic;

    using Fiveforty.Module.Units.ModelViews;
    using Fiveforty.Queries;

    public record GetUnitSummaryInformationsList(int Take = 0, int Skip = 0) : Query<List<UnitSummaryInformations>>
    {
    }
}