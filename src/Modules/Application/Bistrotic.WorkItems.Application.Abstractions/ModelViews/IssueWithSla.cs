namespace Bistrotic.WorkItems.Application.ModelViews
{
    using System;

    public record IssueWithSla(
        string WorkItemId,
        string WorkItemUrl,
        string Title,
        string ProjectName,
        string Assignee,
        int Priority,
        DateTime CreatedDateTime,
        DateTime? AcknowledgedDateTime,
        int AcknoledgeRemainingTimeInSeconds,
        DateTime? ClosedDateTime,
        int ResolutionDurationInSeconds,
        int RemainingResolutionTimeInSeconds,
        int SlaSuspendedTimeInSeconds,
        int WaitingForActionTimeInSeconds
        )
    {
    }
}