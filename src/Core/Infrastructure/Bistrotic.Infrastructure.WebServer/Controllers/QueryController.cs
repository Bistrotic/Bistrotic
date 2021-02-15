namespace Bistrotic.Infrastructure.WebServer.Controllers
{
    using System;
    using System.Security.Principal;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly ILogger<QueryController> _logger;
        private readonly IPrincipal _principal;
        private readonly IQueryDispatcher _queryDispatcher;

        public QueryController(IQueryDispatcher queryDispatcher, ILogger<QueryController> logger, IPrincipal principal)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _principal = principal ?? throw new ArgumentNullException(nameof(principal));
        }

        [HttpGet("ask")]
        public async Task<IActionResult> Ask(string assemblyQualifiedName, string jsonValue)
        {
            UserName userName = _principal.Identity?.Name ?? "anonymous";
            IQuery query = (IQuery)new JsonMessage(assemblyQualifiedName, jsonValue).GetMessage();
            var queryType = query.GetType();
            _logger.LogDebug($"User '{userName}' asked for query : {queryType.Name}");
            try
            {
                return Ok(await _queryDispatcher
                    .Dispatch(new Envelope<IQuery>(
                        query,
                        userName
                        ))
                    .ConfigureAwait(false));
            }
            catch (QueryHandlerNotFoundException)
            {
                _logger.LogError($"User '{userName}' asked for unkown query : {queryType.Name}");
                return BadRequest(new { Query = queryType.Name });
            }
            catch (BusinessObjectNotFoundException ex)
            {
                _logger.LogError($"User '{userName}' asked for a not found business object '{ex.Name}' with id '{ex.Id}'. Query {queryType.Name}");
                return NotFound(new { ex.Id, ex.Name });
            }
        }
    }
}