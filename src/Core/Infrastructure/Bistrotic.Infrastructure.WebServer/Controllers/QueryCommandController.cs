namespace Bistrotic.Infrastructure.WebServer.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[action]")]
    public class QueryCommandController : ControllerBase
    {
        private readonly ILogger<QueryCommandController> _logger;
        private readonly IMessageFactory _messageFactory;
        private readonly IQueryDispatcher _queryDispatcher;

        public QueryCommandController(IQueryDispatcher queryDispatcher, IMessageFactory messageFactory, ILogger<QueryCommandController> logger)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
            _messageFactory = messageFactory;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{queryName}")]
        public async Task<IActionResult> Ask(string queryName)
        {
            string? userName = User?.Identity?.Name;
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "nonidentified";
                //return Unauthorized("User name is not defined");
            }
            IQuery query = (IQuery)_messageFactory.GetMessage(queryName, HttpContext.Request.Query);
            var queryType = query.GetType();
            _logger.LogDebug($"User '{userName}' asked for query : {queryType.Name}");
            try
            {
                return Ok(await _queryDispatcher
                    .Dispatch(new Envelope<IQuery>(
                        query,
                        new MessageId(),
                        userName
                        ))
                    .ConfigureAwait(false));
            }
            catch (QueryHandlerNotFoundException e)
            {
                _logger.LogError($"Error while asking for query '{queryType.Name}' by the user '{userName}'.\n{e.Message}");
                return BadRequest(new { Query = queryType.Name });
            }
            catch (BusinessObjectNotFoundException ex)
            {
                _logger.LogError($"User '{userName}' asked for a not found business object '{ex.Name}' with id '{ex.Id}'. Query {queryType.Name}");
                return NotFound(new { ex.Id, ex.Name });
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while asking for query '{queryType.Name}' by the user '{userName}'.\n{e.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost("{commandName}")]
        public async Task<IActionResult> Tell(string commandName, [FromBody] string jsonValue)
        {
            if (string.IsNullOrWhiteSpace(User?.Identity?.Name))
                return Unauthorized("User name is not defined");
            ICommand command = (ICommand)_messageFactory.GetMessage(commandName, HttpUtility.HtmlDecode(jsonValue));
            var commandType = command.GetType();
            _logger.LogDebug($"User '{User.Identity.Name}' told to execute command : {commandType.Name}");
            try
            {
                return Ok(await _queryDispatcher
                    .Dispatch(new Envelope<ICommand>(
                        command,
                        new MessageId(),
                        User.Identity.Name
                        ))
                    .ConfigureAwait(false));
            }
            catch (CommandHandlerNotFoundException)
            {
                _logger.LogError($"User '{User.Identity.Name}' told to execute an unkown command : {commandType.Name}");
                return BadRequest(new { Query = commandType.Name });
            }
            catch (BusinessObjectNotFoundException ex)
            {
                _logger.LogError($"User '{User.Identity.Name}' tried to execute an action on business object '{ex.Name}' with id '{ex.Id}', but it's not found. Command {commandType.Name}");
                return NotFound(new { ex.Id, ex.Name });
            }
        }
    }
}