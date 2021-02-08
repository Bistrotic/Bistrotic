namespace Bistrotic.Infrastructure.BlazorClient
{
    using System;
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
            var result = await _httpClient.GetFromJsonAsync<TResult>($"api/query/{query.GetType().FullName}/{JsonSerializer.Serialize(query)}");
            if (result == null)
            {
                throw new QueryResultNullException(query);
            }
            return result;
        }

        public async Task Tell<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _httpClient.PostAsJsonAsync($"api/command/{command.GetType().FullName}", command);
        }
    }
}