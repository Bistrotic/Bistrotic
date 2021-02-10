namespace Bistrotic.Units.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.Units.Domain;

    public record GetUnitSearchMatching(string Pattern, int Take = 0, int Skip = 0) : Query<List<int>>(UnitConstants.DomainName)
    {
    }
}