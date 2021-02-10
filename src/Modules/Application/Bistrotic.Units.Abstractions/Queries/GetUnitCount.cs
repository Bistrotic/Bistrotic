namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Units.Domain;

    public record GetUnitCount() : Query<int>(UnitConstants.DomainName)
    {
    }
}