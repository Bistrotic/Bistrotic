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
        [HttpPost(""api/{{ modulename | string.downcase }}/{{ command.name | string.downcase }}"")]
        public Task<IActionResult> {{ command.name }}([FromBody] {{ command.name }} command)
        {
            return base.Tell(command);
        }
{{ end }}
    }
}
";
    }
}