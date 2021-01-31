namespace Fiveforty.Module.Units.Queries
{
    using Fiveforty.Queries;

    public record GetAllUnitIds(int Take, int Skip) : Query<string>
    {
    }
}