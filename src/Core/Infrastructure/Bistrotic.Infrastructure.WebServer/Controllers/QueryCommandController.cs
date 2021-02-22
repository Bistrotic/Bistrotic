namespace Bistrotic.Infrastructure.WebServer.Controllers
{
    using System;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using System.Web;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[action]")]
    public class QueryCommandController : ControllerBase
    {
        private readonly ILogger<QueryCommandController> _logger;
        private readonly IMessageFactory _messageFactory;
        private readonly IPrincipal _principal;
        private readonly IQueryDispatcher _queryDispatcher;

        public QueryCommandController(IQueryDispatcher queryDispatcher, IMessageFactory messageFactory, ILogger<QueryCommandController> logger, IPrincipal principal)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _messageFactory = messageFactory;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _principal = principal ?? throw new ArgumentNullException(nameof(principal));
        }

        [HttpGet("{queryName}/{jsonValue}")]
        public async Task<IActionResult> Ask(string queryName, string jsonValue)
        {
            UserName userName = _principal.Identity?.Name ?? "anonymous";
            IQuery query = (IQuery)_messageFactory.GetMessage(queryName, HttpUtility.HtmlDecode(jsonValue));
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

        [HttpPost("{commandName}")]
        public async Task<IActionResult> Tell(string commandName, [FromBody] string jsonValue)
        {
            UserName userName = _principal.Identity?.Name ?? "anonymous";
            ICommand command = (ICommand)_messageFactory.GetMessage(commandName, HttpUtility.HtmlDecode(jsonValue));
            var commandType = command.GetType();
            _logger.LogDebug($"User '{userName}' told to execute command : {commandType.Name}");
            try
            {
                return Ok(await _queryDispatcher
                    .Dispatch(new Envelope<ICommand>(
                        command,
                        userName
                        ))
                    .ConfigureAwait(false));
            }
            catch (CommandHandlerNotFoundException)
            {
                _logger.LogError($"User '{userName}' told to execute an unkown command : {commandType.Name}");
                return BadRequest(new { Query = commandType.Name });
            }
            catch (BusinessObjectNotFoundException ex)
            {
                _logger.LogError($"User '{userName}' tried to execute an action on business object '{ex.Name}' with id '{ex.Id}', but it's not found. Command {commandType.Name}");
                return NotFound(new { ex.Id, ex.Name });
            }
        }
    }
}