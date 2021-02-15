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

    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

    public class GetIssuesWithSlaHandler : QueryHandler<GetIssuesWithSla, List<IssueWithSla>>
    {
        private readonly IQueryDispatcher _queryDispatcher;

        private var list = new List<IssueWithSla>()
            {
                new IssueWithSla("56",
                "",
                "Test 1",
                "Eden Park",
                "jpiquot@fiveforty.fr",
                2,
                DateTime.Now - new TimeSpan(1, 26, 10),
                DateTime.Now - new TimeSpan(1, 16, 20),
                0,
                null,
                0,
                36700,
                3000,
                0
                ),
                new IssueWithSla("68",
                "",
                "Test 2",
                "Eden Park",
                "jpiquot@fiveforty.fr",
                2,
                DateTime.Now - new TimeSpan(2, 35, 20),
                null,
                5000,
                null,
                2000,
                6000,
                0,
                1000
                ),
                new IssueWithSla("75",
                "",
                "Test 3",
                "Eden Park",
                "jlascaux@fiveforty.fr",
                2,
                DateTime.Now - new TimeSpan(4, 26, 10),
                DateTime.Now - new TimeSpan(4, 0, 0),
                0,
                null,
                2500,
                36700,
                1000,
                5000
                )
            };

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
            var server = new Server(settings.AzureDevOpsServerUrl, settings.PersonalAccessToken);

            server.Connect();
            var wiql = "Select [Id] " +
                    "From WorkItems " +
                    "Where [Work Item Type] = 'Issue' " +
                    "Order By [State] Asc, [Changed Date] Desc";

            var query = new Query(server, wiql, new[] { "System.Id", "System.Title", "System.State" });
            List<WorkItem> wis = await query.GetQueryWorkItems();
            var issues = new List<IssueWithSla>(wis.Count);
            foreach (var wi in wis)
            {
                issues.Add(new IssueWithSla
                {
                    WorkItemId = wi.Id,
                    WorkItemUrl = wi.Url,
                    Title = (string)wi.Fields[WorkItemFieldType.Title],
                    ProjectName = wi.,
                    string Assignee,
                    int Priority,
                    DateTime CreatedDateTime,
                    DateTime ? AcknowledgedDateTime,
                    int AcknoledgeRemainingTimeInSeconds,
                    DateTime ? ClosedDateTime,
                    int ResolutionDurationInSeconds,
                    int RemainingResolutionTimeInSeconds,
                    int SlaSuspendedTimeInSeconds,
                    int WaitingForActionTimeInSeconds
                });
            }
        }
    }
}