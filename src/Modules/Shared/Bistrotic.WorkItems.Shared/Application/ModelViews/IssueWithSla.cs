namespace Bistrotic.WorkItems.Application.ModelViews
{
    using System;

    public sealed class IssueWithSla
    {
        public int AcknoledgeRemainingTimeInSeconds { get; init; }
        public DateTime? AcknowledgedDateTime { get; init; }
        public string? Assignee { get; init; }
        public DateTime? ClosedDateTime { get; init; }
        public DateTime CreatedDateTime { get; init; }
        public int Priority { get; init; }
        public string? ProjectName { get; init; }
        public int RemainingResolutionTimeInSeconds { get; init; }
        public int ResolutionDurationInSeconds { get; init; }
        public int SlaSuspendedTimeInSeconds { get; init; }
        public string? Title { get; init; }
        public int WaitingForActionTimeInSeconds { get; init; }
        public int WorkItemId { get; init; }
        public string? WorkItemUrl { get; init; }
    }
}