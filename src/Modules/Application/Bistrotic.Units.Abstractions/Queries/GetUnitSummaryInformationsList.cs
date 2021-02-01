namespace Bistrotic.Module.Units.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Module.Units.ModelViews;

    public record GetUnitSummaryInformationsList(UserName UserName, int Take = 0, int Skip = 0)
        : Query<List<UnitSummaryInformations>>(UserName, null)
    {
    }
}