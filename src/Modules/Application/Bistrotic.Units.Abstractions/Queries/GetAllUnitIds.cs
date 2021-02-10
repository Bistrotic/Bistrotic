using System.Collections.Generic;

using Bistrotic.Application.Queries;
using Bistrotic.Units.Domain;

namespace Bistrotic.Units.Application.Queries
{
    public record GetAllUnitIds(int Take, int Skip) : Query<List<int>>(UnitConstants.DomainName)
    {
    }
}