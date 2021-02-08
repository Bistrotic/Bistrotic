namespace Bistrotic.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CommandController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CommandController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("{assemblyName}/{commandName}")]
        public async Task<IActionResult> Get(string assemblyName, string commandName, [FromBody] string commandValue)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == assemblyName);
            if (assembly == null)
            {
                return NotFound($"Assembly '{assemblyName}' not found for command '{commandName}'.");
            }
            var commandType = assembly.GetType(commandName);
            if (commandType == null)
            {
                return NotFound($"command '{commandName}' not found in assembly '{assemblyName}'.");
            }
            try
            {
                if (JsonSerializer.Deserialize(commandValue, commandType) is ICommand command)
                {
                    await _commandDispatcher
                        .Dispatch(command)
                        .ConfigureAwait(false);
                    return Ok();
                }
                else
                {
                    return BadRequest($"The command value of '{commandType}' can't be deserialized.");
                }
            }
            catch (CommandHandlerNotFoundException)
            {
                return NotFound($"command handler for command '{commandName}' not found.");
            }
        }
    }
}