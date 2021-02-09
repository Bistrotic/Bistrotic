namespace Bistrotic.WorkItems.Server
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class WorkItemsController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public WorkItemsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public Task<List<IssueWithSla>> GetIssuesWithSla(bool suspendedSla = false, bool closedIssues = false)
            => _queryDispatcher.Dispatch<GetIssuesWithSla, List<IssueWithSla>>(new GetIssuesWithSla(suspendedSla, closedIssues));
    }
}