namespace Bistrotic.Infrastructure.CodeGeneration.Generators.WebApi
{
    public static class QueryCommandControllerTemplate
    {
        public const string Value = @"
namespace {{namespace}}
{
{{ for u in usings }}
    using {{ u }};
{{ end }}

    [ApiController]
    [Authorize]
    [Route(""api/{{ modulename | string.downcase }}/[action]"")]
    public sealed class {{ modulename }}ApiController : QueryCommandControllerBase
    {
         public {{ modulename }}ApiController(
            IQueryDispatcher queryDispatcher,
            IMessageFactory messageFactory,
            ILogger<{{ modulename }}ApiController> logger)
            : base(queryDispatcher, messageFactory, logger)
        {
        }
{{ for command in commands }}
        [HttpPost]
        public Task<IActionResult> {{ command.name }}(string messageId, [FromBody] {{ command.name }} command)
        {
            return base.Tell(messageId, command);
        }
{{ end }}

        [HttpGet]
        public IActionResult Test()
        {
            return Ok(""hello you, from {{ modulename }}."");
        }
    }
}
";
    }
}