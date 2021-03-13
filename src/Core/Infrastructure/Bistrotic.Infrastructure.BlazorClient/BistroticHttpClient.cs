namespace Bistrotic.Infrastructure.BlazorClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    using Bistrotic.Application;
    using Bistrotic.Application.Client.Exceptions;
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.Helpers;

    public class BistroticHttpClient : IQueryService, ICommandService
    {
        public BistroticHttpClient(HttpClient httpClient)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public HttpClient HttpClient { get; }

        public async Task<TResult> Ask<TQuery, TResult>(string messageId, TQuery query) where TQuery : class, IQuery<TResult>
        {
            var queryType = typeof(TQuery);
            try
            {
                var result = await HttpClient
                    .GetFromJsonAsync<TResult>(query.ToHttpQueryString($"api/ask/{queryType.Name.ToLowerInvariant()}/?MessageId={messageId}"));
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

        public async Task Tell<TCommand>(string messageId, TCommand command) where TCommand : ICommand
        {
            var commandType = typeof(TCommand);
            try
            {
                await HttpClient.PostAsJsonAsync($"api/tell/{commandType.Name.ToLowerInvariant()}/?MessageId={messageId}", command.Json());
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