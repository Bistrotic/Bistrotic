namespace Bistrotic.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Queries;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public QueryController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher ?? throw new ArgumentNullException(nameof(queryDispatcher));
        }

        [HttpGet("{assemblyName}/{queryName}/{queryValue}")]
        public async Task<IActionResult> Get(string assemblyName, string queryName, string queryValue)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(assembly => assembly.GetName().Name == assemblyName);
            if (assembly == null)
            {
                return NotFound($"Assembly '{assemblyName}' not found for query '{queryName}'.");
            }
            var queryType = assembly.GetType(queryName);
            if (queryType == null)
            {
                return NotFound($"Query '{queryName}' not found in assembly '{assemblyName}'.");
            }
            try
            {
                if (JsonSerializer.Deserialize(queryValue, queryType) is IQuery query)
                {
                    return Ok(await _queryDispatcher
                        .Dispatch(query)
                        .ConfigureAwait(false));
                }
                else
                {
                    return BadRequest($"The query value of '{queryType}' can't be deserialized.");
                }
            }
            catch (QueryHandlerNotFoundException)
            {
                return NotFound($"Query handler for query '{queryName}' not found.");
            }
        }
    }
}