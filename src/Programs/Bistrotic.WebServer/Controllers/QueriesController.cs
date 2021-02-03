using System.Threading.Tasks;

using Bistrotic.Units.Application.ModelViews;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bistrotic.WebServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueriesController : ControllerBase
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly ILogger<QueriesController> _logger;
#pragma warning restore IDE0052 // Remove unread private members

        public QueriesController(ILogger<QueriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ask/{query}")]
        public Task<IActionResult> Ask(string query)
        {
            _logger.LogDebug($"Ask for query : {query}");
            return Task.FromResult<IActionResult>(Ok(new UnitSummaryInformations[]
            {
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
            }));
        }
    }
}