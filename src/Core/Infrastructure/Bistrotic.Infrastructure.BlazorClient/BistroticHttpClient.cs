﻿namespace Bistrotic.Infrastructure.BlazorClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Bistrotic.Application;
    using Bistrotic.Application.Client.Exceptions;
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Infrastructure.Helpers;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.WebUtilities;

    public class BistroticHttpClient : IQueryService, ICommandService
    {
        public BistroticHttpClient(HttpClient httpClient, NavigationManager navigationManager)
        {
            HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            NavigationManager = navigationManager;
        }

        public HttpClient HttpClient { get; }
        public NavigationManager NavigationManager { get; }

        public async Task<TResult> Ask<TQuery, TResult>(string? messageId, TQuery query) where TQuery : class, IQuery<TResult>
        {
            var queryType = typeof(TQuery);
            try
            {
                var queryList = new Dictionary<string, string>(
                    query
                    .GetPropertyNotNullValues()
                    .Select(p => new KeyValuePair<string, string>(p.Key, JsonSerializer.Serialize(p.Value))))
                {
                    // { "MessageId", string.IsNullOrWhiteSpace(messageId) ? new MessageId() :
                    // messageId }
                };

                var url = QueryHelpers.AddQueryString($"api/ask/{queryType.Name.ToLowerInvariant()}/", queryList);
                var result = await HttpClient
                    .GetFromJsonAsync<TResult>(url);
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

        public async Task Tell<TCommand>(string? messageId, TCommand command) where TCommand : ICommand
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