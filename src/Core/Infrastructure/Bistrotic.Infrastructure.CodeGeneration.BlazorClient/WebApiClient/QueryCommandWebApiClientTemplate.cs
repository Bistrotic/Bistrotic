namespace Bistrotic.Infrastructure.CodeGeneration.WebApiClient
{
    public static class QueryCommandWebApiClientTemplate
    {
        public const string Value = @"
namespace {{namespace}}
{
{{ for u in usings }}
    using {{ u }};
{{ end }}

    public sealed class {{ modulename }}WebApiClient : QueryCommandWebApiClientBase
    {
        public {{ modulename }}WebApiClient(HttpClient httpClient) : base(httpClient, ""{{ moduleName }}"")
        {
        }

{{ for command in commands }}
        public Task {{ command.name }}({{ command.name }} command, string? messageId = null)
        {
            return Tell(command, messageId);
        }
{{ end }}
    }
}
";
    }
}