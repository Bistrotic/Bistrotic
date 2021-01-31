namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Queries;

    public record GetAllUnitIds(int Take, int Skip) : Query<string>
    {
    }
}