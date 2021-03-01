namespace Bistrotic.WorkItems.Application.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.Exceptions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;
    using Bistrotic.WorkItems.Domain;
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
            if (string.IsNullOrWhiteSpace(settings.SlaGroupName))
            {
                throw new MissingSettingsException<WorkItemModuleSettings>(nameof(WorkItemModuleSettings.SlaGroupName));
            }
            var slaMembers = await _queryDispatcher
                .Dispatch<GetSecurityGroupMembers, IEnumerable<SecurityGroupMember>>(
                new Envelope<GetSecurityGroupMembers>(new GetSecurityGroupMembers(settings.SlaGroupName), envelope)
                );

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
                var wiHistory = await _queryDispatcher
                    .Dispatch<GetWorkItemChangeHistory, IEnumerable<WorkItemChange>>(
                    new Envelope<GetWorkItemChangeHistory>(new GetWorkItemChangeHistory(new WokItemId(wi.Id.ToString())), envelope)
                    );
                var slaHistory = wiHistory
                    .OrderBy(p => p.ChangeDate)
                    .Select(p => new { p.ChangeDate, IsSla = slaMembers.Any(o => o.Name == p.UserName) })
                    .ToList();
                DateTime? acknowledgeDate = slaHistory.Where(p => p.IsSla).Select(p => p.ChangeDate).FirstOrDefault();
                const int acknowledgeTime = 3600;
                const int resolutionTime = 3600 * 8 * 5;
                issues.Add(new IssueWithSla
                {
                    WorkItemId = wi.Id,
                    WorkItemUrl = wi.HtmlUrl,
                    Title = wi.Title,
                    ProjectName = wi.TeamProject,
                    Assignee = wi.AssignedTo,
                    Priority = (int)wi.Priority,
                    CreatedDateTime = wi.CreatedDate,
                    AcknowledgedDateTime = acknowledgeDate,
                    AcknoledgeRemainingTimeInSeconds = acknowledgeDate == null ? 0 : acknowledgeTime - (int)(DateTime.Now - wi.CreatedDate).TotalSeconds,
                    ClosedDateTime = wi.ClosedDate,
                    ResolutionDurationInSeconds = wi.ClosedDate == null ? 0 : (int)(wi.ClosedDate.Value - wi.CreatedDate).TotalSeconds,
                    RemainingResolutionTimeInSeconds = wi.ClosedDate == null ? resolutionTime - (int)(DateTime.Now - wi.CreatedDate).TotalSeconds : 0,
                    SlaSuspendedTimeInSeconds = (slaHistory.LastOrDefault()?.IsSla == true) ? 0 : (int)(DateTime.Now - wi.ChangedDate.Value).TotalSeconds,
                    WaitingForActionTimeInSeconds = (slaHistory.LastOrDefault()?.IsSla == true) ? (int)(DateTime.Now - wi.ChangedDate.Value).TotalSeconds : 0
                });
            }
            return issues;
        }
    }
}