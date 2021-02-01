namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;

    public record GetUnitCount(UserName UserName)
        : Query<string>(UserName, null)
    {
    }
}