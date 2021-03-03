namespace Bistrotic.QuartzScheduler.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.Application.Queries;
    using Bistrotic.QuartzScheduler.Application.ModelViews;

    public class GetJobSummaryList : Query<IEnumerable<JobSummary>>
    {
    }
}