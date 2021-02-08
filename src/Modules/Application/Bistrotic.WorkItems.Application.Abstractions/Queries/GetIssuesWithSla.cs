namespace Bistrotic.WorkItems.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;

    public record GetIssuesWithSla(
                    bool SuspendedSla = false,
                    bool ClosedIssues = false
        ) : Query<List<IssueWithSla>>
    {
    }
}