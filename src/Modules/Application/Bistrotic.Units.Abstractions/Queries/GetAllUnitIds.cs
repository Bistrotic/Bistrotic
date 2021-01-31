namespace Bistrotic.Module.Units.Queries
{
    using Bistrotic.Queries;

    public record GetAllUnitIds(int Take, int Skip) : Query<string>
    {
    }
}