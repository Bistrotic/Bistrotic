namespace Bistrotic.Infrastructure.BlazorClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;

    using System.Text.Json;
    using System.Threading.Tasks;

    using Bistrotic.Application.Client.Exceptions;
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Queries;

    public class HttpCommandQueryClient : IQueryService, ICommandService
    {
        private readonly HttpClient _httpClient;

        public HttpCommandQueryClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TResult> Ask<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            try
            {
                var result = await _httpClient
                    .GetFromJsonAsync<TResult>($"api/query/{query.GetType().Assembly.GetName().Name}/{query.GetType().FullName}/{JsonSerializer.Serialize(query)}")
                    .ConfigureAwait(false);
                if (result == null)
                {
                    throw new QueryResultNullException(query);
                }
                return result;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Handle 404
                Console.WriteLine($"Query handler for '{query.GetType().Name}' not found: " + ex.Message);
                throw;
            }
        }

        public async Task Tell<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"api/command/{command.GetType().Assembly.GetName().Name}/{command.GetType().FullName}", command);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Handle 404
                Console.WriteLine($"Command handler for '{command.GetType().Name}' not found: " + ex.Message);
                throw;
            }
        }
    }
}