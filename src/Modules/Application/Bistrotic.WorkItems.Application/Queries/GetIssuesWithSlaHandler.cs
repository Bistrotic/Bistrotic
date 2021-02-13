namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.Application.Queries;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System;
    using Bistrotic.Application.Messages;

    public class GetIssuesWithSlaHandler : QueryHandler<GetIssuesWithSla, List<IssueWithSla>>
    {
        public override Task<List<IssueWithSla>> Handle(Envelope<GetIssuesWithSla> query)
        {
            return Task.FromResult(new List<IssueWithSla>()
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
            });
        }
    }
}