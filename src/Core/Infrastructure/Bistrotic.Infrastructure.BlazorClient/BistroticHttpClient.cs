namespace Bistrotic.Infrastructure.BlazorClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Web;

    using Bistrotic.Application;
    using Bistrotic.Application.Client.Exceptions;
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Queries;

    public class BistroticHttpClient : IQueryService, ICommandService
    {
        private const string _commandUrl = "api/command/tell/";
        private const string _jsonValueName = "Value";
        private const string _queryUrl = "api/query/ask/";

        public BistroticHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public HttpClient HttpClient { get; }

        public async Task<TResult> Ask<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var queryType = typeof(TQuery);
            try
            {
                var result = await HttpClient
                    .GetFromJsonAsync<TResult>($"api/ask/{queryType.Name.ToLowerInvariant()}/{HttpUtility.HtmlEncode(query.Json())}");
                if (result == null)
                {
                    throw new QueryResultNullException(query);
                }
                return result;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Handle 404
                Console.WriteLine($"Query handler for '{queryType.Name}' not found: " + ex.Message);
                throw;
            }
        }

        public async Task Tell<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandType = typeof(TCommand);
            try
            {
                await HttpClient.PostAsJsonAsync($"api/tell/{commandType.Name.ToLowerInvariant()}", command.Json());
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Handle 404
                Console.WriteLine($"Query handler for '{commandType.Name}' not found: " + ex.Message);
                throw;
            }
        }
    }
}