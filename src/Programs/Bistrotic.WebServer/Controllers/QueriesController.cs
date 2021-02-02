using System;
using System.Collections.Generic;

using Bistrotic.Units.Application.ModelViews;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bistrotic.Server.Controllers
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

        [HttpGet]
        public IEnumerable<UnitSummaryInformations> GetUnitSummaryInformations()
        {
            var rng = new Random();
            return new UnitSummaryInformations[]
            {
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
                new UnitSummaryInformations("L", "Liter"),
            };
        }
    }
}