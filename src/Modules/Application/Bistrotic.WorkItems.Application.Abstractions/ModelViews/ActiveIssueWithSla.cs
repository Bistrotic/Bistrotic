namespace Bistrotic.WorkItems.Application.Abstractions.ModelViews
{
    using System;

    public record ActiveIssueWithSla(
        string WorkItemId,
        string Title,
        DateTime CreatedTime,
        DateTime? AcknoledgedTime,
        int AcknoledgeRemainingTimeInSeconds,
        int ResolutionDurationInSeconds,
        int RemainingResolutionTimeInSeconds,
        string Assignee,
        int Priority,
        bool SlaSuspended,
        bool IssueClosed)
    {
    }
}