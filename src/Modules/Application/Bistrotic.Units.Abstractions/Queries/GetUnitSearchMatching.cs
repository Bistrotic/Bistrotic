namespace Bistrotic.Units.Application.Queries
{
    public record GetUnitSearchMatching(string Pattern, int Take = 0, int Skip = 0)
    {
    }
}