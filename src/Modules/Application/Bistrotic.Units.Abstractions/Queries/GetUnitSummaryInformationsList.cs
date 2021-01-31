﻿namespace Bistrotic.Module.Units.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Module.Units.ModelViews;
    using Bistrotic.Queries;

    public record GetUnitSummaryInformationsList(int Take = 0, int Skip = 0) : Query<List<UnitSummaryInformations>>
    {
    }
}