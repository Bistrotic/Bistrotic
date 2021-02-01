namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;

    public record GetAllUnitIds(UserName UserName, int Take, int Skip)
        : Query<string>(UserName, null)
    {
    }
}