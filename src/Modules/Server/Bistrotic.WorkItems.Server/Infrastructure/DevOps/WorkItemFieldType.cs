﻿namespace Bistrotic.WorkItems.Infrastructure.DevOps
{
    /// <summary>
    /// Class WorkItemFieldType.
    /// </summary>
    /// <autogeneratedoc/>
    public static class WorkItemFieldType
    {
        public const string ActivatedBy = "Microsoft.VSTS.Common.ActivatedBy";
        public const string ActivatedDate = "Microsoft.VSTS.Common.ActivatedDate";

        /// <summary>
        /// The activity. Type of work involved
        /// </summary>
        public const string Activity = "Microsoft.VSTS.Common.Activity";

        public const string AreaId = "System.AreaId";

        /// <summary>
        /// The area path The area of the product with which this bug is associated
        /// </summary>
        public const string AreaPath = "System.AreaPath";

        /// <summary>
        /// The assigned to The person currently working on this bug
        /// </summary>
        /// <autogeneratedoc/>
        public const string AssignedTo = "System.AssignedTo";

        public const string AttachedFileCount = "System.AttachedFileCount";
        public const string AttachedFiles = "System.AttachedFiles";
        public const string AuthorizedAs = "System.AuthorizedAs";
        public const string AuthorizedDate = "System.AuthorizedDate";
        public const string BISLinks = "System.BISLinks";
        public const string BoardColumn = "System.BoardColumn";
        public const string BoardColumnDone = "System.BoardColumnDone";
        public const string BoardLane = "System.BoardLane";
        public const string ChangedBy = "System.ChangedBy";
        public const string ChangedDate = "System.ChangedDate";
        public const string ClosedBy = "Microsoft.VSTS.Common.ClosedBy";
        public const string ClosedDate = "Microsoft.VSTS.Common.ClosedDate";

        /// <summary>
        /// The completed work. The number of units of work that have been spent on this bug.
        /// </summary>
        public const string CompletedWork = "Microsoft.VSTS.Scheduling.CompletedWork";

        public const string CreatedBy = "System.CreatedBy";
        public const string CreatedDate = "System.CreatedDate";
        public const string Description = "System.Description";

        /// <summary>
        /// The external link count
        /// </summary>
        /// <autogeneratedoc/>
        public const string ExternalLinkCount = "System.ExternalLinkCount";

        /// <summary>
        /// The found in The build in which the bug was found
        /// </summary>
        public const string FoundIn = "Microsoft.VSTS.Build.FoundIn";

        /// <summary>
        /// The history Discussion thread plus automatic record of changes
        /// </summary>
        public const string History = "System.History";

        public const string HyperLinkCount = "System.HyperLinkCount";
        public const string Id = "System.Id";

        /// <summary>
        /// The integration build The build in which the bug was fixed
        /// </summary>
        public const string IntegrationBuild = "Microsoft.VSTS.Build.IntegrationBuild";

        /// <summary>
        /// The iteration identifier
        /// </summary>
        /// <autogeneratedoc/>
        public const string IterationId = "System.IterationId";

        /// <summary>
        /// The iteration path The iteration within which this bug will be fixed
        /// </summary>
        public const string IterationPath = "System.IterationPath";

        public const string LinkedFiles = "System.LinkedFiles";
        public const string NodeName = "System.NodeName";

        /// <summary>
        /// The original estimate. Initial value for Remaining Work - set once, when work begins
        /// </summary>
        public const string OriginalEstimate = "Microsoft.VSTS.Scheduling.OriginalEstimate";

        /// <summary>
        /// The priority Business importance. 1=must fix; 4=unimportant.
        /// </summary>
        public const string Priority = "Microsoft.VSTS.Common.Priority";

        /// <summary>
        /// The reason "The reason why the bug is in the current state"
        /// </summary>
        public const string Reason = "System.Reason";

        public const string RelatedLinkCount = "System.RelatedLinkCount";

        public const string RelatedLinks = "System.RelatedLinks";

        /// <summary>
        /// The remaining work. An estimate of the number of units of work remaining to complete
        /// this bug.
        /// </summary>
        public const string RemainingWork = "Microsoft.VSTS.Scheduling.RemainingWork";

        /// <summary>
        /// The repro steps How to see the bug. End by contrasting expected with actual behavior.
        /// </summary>
        public const string ReproSteps = "Microsoft.VSTS.TCM.ReproSteps";

        public const string ResolvedBy = "Microsoft.VSTS.Common.ResolvedBy";

        public const string ResolvedDate = "Microsoft.VSTS.Common.ResolvedDate";

        /// <summary>
        /// The resolved reason The reason why the bug was resolved.
        /// </summary>
        public const string ResolvedReason = "Microsoft.VSTS.Common.ResolvedReason";

        public const string Rev = "System.Rev";

        public const string RevisedDate = "System.RevisedDate";

        /// <summary>
        /// The severity Assessment of the effect of the bug on the project.
        /// </summary>
        public const string Severity = "Microsoft.VSTS.Common.Severity";

        /// <summary>
        /// The stack rank Work first on items with lower-valued stack rank. Set in triage.
        /// </summary>
        /// <autogeneratedoc/>
        public const string StackRank = "Microsoft.VSTS.Common.StackRank";

        /// <summary>
        /// The state New = for triage; Active = not yet fixed; Resolved = fixed not yet verified;
        /// Closed = fix verified.
        /// </summary>
        public const string State = "System.State";

        public const string StateChangeDate = "Microsoft.VSTS.Common.StateChangeDate";

        /// <summary>
        /// The story points The size of work estimated for fixing the bug.
        /// </summary>
        public const string StoryPoints = "Microsoft.VSTS.Scheduling.StoryPoints";

        /// <summary>
        /// The system information Test context, provided automatically by test infrastructure.
        /// </summary>
        public const string SystemInfo = "Microsoft.VSTS.TCM.SystemInfo";

        public const string Tags = "System.Tags";

        public const string TeamProject = "System.TeamProject";

        /// <summary>
        /// The title type.
        /// </summary>
        /// <autogeneratedoc/>
        public const string Title = "System.Title";

        /// <summary>
        /// The value area The type should be set to Business primarily to represent customer-facing
        /// issues. Work to change the architecture should be added as a User Story.
        /// </summary>
        /// <autogeneratedoc/>
        public const string ValueArea = "Microsoft.VSTS.Common.ValueArea";

        public const string Watermark = "System.Watermark";

        /// <summary>
        /// The work item type.
        /// </summary>
        /// <autogeneratedoc/>
        public const string WorkItemType = "System.WorkItemType";
    }
}