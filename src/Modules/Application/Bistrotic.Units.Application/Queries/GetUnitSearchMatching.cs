﻿namespace Bistrotic.Units.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Units.Application.ModelViews;
    using Bistrotic.Queries;

    public record GetUnitSearchMatching(string Pattern, int Take = 0, int Skip = 0) : Query<List<UnitSummaryInformations>>
    {
    }
}