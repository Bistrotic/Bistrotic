namespace Bistrotic.WorkItems.Server
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class WorkItemController : Controller
    {
        private readonly ILogger<WorkItemController> _logger;
        private readonly IQueryDispatcher _queryDispatcher;

        public WorkItemController(IQueryDispatcher queryDispatcher, ILogger<WorkItemController> logger)
        {
            _queryDispatcher = queryDispatcher;
            _logger = logger;
        }

        [HttpGet(nameof(GetIssuesWithSla))]
        public Task<List<IssueWithSla>> GetIssuesWithSla([FromQuery] GetIssuesWithSla query)
            => Ask<GetIssuesWithSla, List<IssueWithSla>>(query);

        [HttpGet(nameof(GetWorkItemModuleSettings))]
        public Task<WorkItemModuleSettings> GetWorkItemModuleSettings([FromQuery] GetWorkItemModuleSettings query)
            => Ask<GetWorkItemModuleSettings, WorkItemModuleSettings>(query);

        private Task<TResult> Ask<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            _logger.LogDebug($"Ask for query : {typeof(TQuery).Name}");
            return _queryDispatcher.Dispatch<TQuery, TResult>(query);
        }
    }
}