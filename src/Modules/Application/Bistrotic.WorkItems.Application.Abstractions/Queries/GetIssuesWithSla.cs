namespace Bistrotic.WorkItems.Application.Abstractions.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.Abstractions.ModelViews;

    public record GetIssuesWithSla(
        string SlaGroupName,
        int[] AcknowlegeTimeInMinutes,
        int[] ResolutionTimeInMinutes,
        bool OnlyActiveSla,
        bool OnlyActiveIssues = true
        ) : Query<ActiveIssueWithSla>
    {
    }
}