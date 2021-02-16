namespace Bistrotic.WorkItems.Application.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.Exceptions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Infrastructure.DevOps;

    using Fd = Infrastructure.DevOps.WorkItemFieldType;

    public class GetIssuesWithSlaHandler : QueryHandler<GetIssuesWithSla, List<IssueWithSla>>
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GetIssuesWithSlaHandler(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public async override Task<List<IssueWithSla>> Handle(Envelope<GetIssuesWithSla> envelope)
        {
            var settings = await _queryDispatcher
                .Dispatch<GetWorkItemModuleSettings, WorkItemModuleSettings>(new Envelope<GetWorkItemModuleSettings>(new GetWorkItemModuleSettings(), envelope));
            if (string.IsNullOrWhiteSpace(settings.AzureDevOpsServerUrl) || string.IsNullOrWhiteSpace(settings.PersonalAccessToken))
            {
                throw new DevOpsServerConfigurationMissingException();
            }
            var server = new DevOpsServer(settings.AzureDevOpsServerUrl, settings.PersonalAccessToken);

            server.Connect();
            const string? wiql = "Select [Id] " +
                    "From WorkItems " +
                    "Where [Work Item Type] = 'Issue' " +
                    "Order By [State] Asc, [Changed Date] Desc";

            var query = new Query(server, wiql, new[]
            {
                Fd.Id,
                Fd.Title,
                Fd.State,
                Fd.TeamProject,
                Fd.AssignedTo,
                Fd.Priority,
                Fd.CreatedDate,
                Fd.ClosedDate
            });
            List<WorkItem> wis = await query.GetQueryWorkItems();
            var issues = new List<IssueWithSla>(wis.Count);
            foreach (var wi in wis)
            {
                issues.Add(new IssueWithSla
                {
                    WorkItemId = wi.Id,
                    WorkItemUrl = wi.HtmlUrl,
                    Title = wi.Title,
                    ProjectName = wi.TeamProject,
                    Assignee = wi.AssignedTo,
                    Priority = (int)wi.Priority,
                    CreatedDateTime = wi.CreatedDate,
                    AcknowledgedDateTime = DateTime.Now.AddDays(-1),
                    AcknoledgeRemainingTimeInSeconds = 10,
                    ClosedDateTime = wi.ClosedDate,
                    ResolutionDurationInSeconds = 100,
                    RemainingResolutionTimeInSeconds = 500,
                    SlaSuspendedTimeInSeconds = 100,
                    WaitingForActionTimeInSeconds = 250
                });
            }
            return issues;
        }
    }
}