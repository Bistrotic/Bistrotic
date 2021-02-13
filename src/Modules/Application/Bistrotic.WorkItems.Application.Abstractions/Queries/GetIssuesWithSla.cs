namespace Bistrotic.WorkItems.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;

    public sealed class GetIssuesWithSla : Query<List<IssueWithSla>>
    {
        public GetIssuesWithSla(bool suspendedSla = false, bool closedIssues = false)
        {
            SuspendedSla = suspendedSla;
            ClosedIssues = closedIssues;
        }

        public bool ClosedIssues { get; }
        public bool SuspendedSla { get; }
    }
}