namespace Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi
{
    public static class QueryCommandControllerTemplate
    {
        public const string Value = @"
namespace {{namespace}}
{
    using System;
    using System.Threading.Tasks;
    using System.Web;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

{{ for u in usings }}
    using {{ u }};
{{ end }}

    [ApiController]
    [Authorize]
    [Route(""api/[{{ modulename }}]"")]
    public class {{ modulename }}ApiController : QueryCommandControllerBase
    {
         public {{ modulename }}ApiController(
            IQueryDispatcher queryDispatcher,
            IMessageFactory messageFactory,
            ILogger<{{ modulename }}ApiController> logger)
            : base(queryDispatcher, messageFactory, logger)
        {
        }
    }
}
";
    }
}