namespace Bistrotic.WorkItems.Server
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;
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
        public Task<ActionResult<List<IssueWithSla>>> GetIssuesWithSla([FromQuery] GetIssuesWithSla query)
            => Ask<GetIssuesWithSla, List<IssueWithSla>>(query);

        [HttpGet(nameof(GetWorkItemModuleSettings))]
        public Task<ActionResult<WorkItemModuleSettings>> GetWorkItemModuleSettings([FromQuery] GetWorkItemModuleSettings query)
            => Ask<GetWorkItemModuleSettings, WorkItemModuleSettings>(query);

        private async Task<ActionResult<TResult>> Ask<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            string userName = User?.Identity?.Name ?? "Anonymous";
#pragma warning disable S125 // Sections of code should not be commented out
            //if (string.IsNullOrWhiteSpace(userName))
            //{
            //    _logger.LogWarning($"Anonymous user asked for query : {typeof(TQuery).Name}");
            //    return Unauthorized();
            //}
            try
            {
                _logger.LogDebug($"User '{User?.Identity?.Name}' asked for query : {typeof(TQuery).Name}");
                return Ok(await _queryDispatcher
                    .Dispatch<TQuery, TResult>(
                        new Envelope<TQuery>(new UserName(userName), query)
                        ));
            }
            catch (QueryHandlerNotFoundException)
            {
                _logger.LogError($"User '{userName}' asked for unkown query : {typeof(TQuery).Name}");
                return BadRequest(new { Query = typeof(TQuery).Name });
            }
            catch (BusinessObjectNotFoundException ex)
            {
                _logger.LogError($"User '{userName}' asked for a not found business object '{ex.Name}' with id '{ex.Id}'. Query {typeof(TQuery).Name}");
                return NotFound(new { ex.Id, ex.Name });
            }
        }
    }
}