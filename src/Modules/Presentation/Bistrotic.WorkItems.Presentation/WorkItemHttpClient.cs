namespace Bistrotic.WorkItems.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Web;

    using Bistrotic.Application.Client.Exceptions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;
    using Bistrotic.WorkItems.Application.Services;
    using Bistrotic.WorkItems.Domain;

    using Microsoft.AspNetCore.WebUtilities;

    public class WorkItemHttpClient : IWorkItemsQueryService, IWorkItemsCommandService
    {
        private readonly string _apiUrl;
        private readonly HttpClient _httpClient;

        public WorkItemHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiUrl = "api/" + WorkItemConstants.DomainName;
        }

        public async Task<List<IssueWithSla>> GetIssuesWithSla(bool SuspendedSla = false, bool ClosedIssues = false)
        {
            try
            {
                var query = new GetIssuesWithSla(SuspendedSla, ClosedIssues);
                var url = _apiUrl;
                url = QueryHelpers.AddQueryString(url, nameof(query.MessageId), HttpUtility.HtmlEncode(query.MessageId) ?? string.Empty);
                url = QueryHelpers.AddQueryString(url, nameof(query.SuspendedSla), HttpUtility.HtmlEncode(query.SuspendedSla) ?? string.Empty);
                url = QueryHelpers.AddQueryString(url, nameof(query.ClosedIssues), HttpUtility.HtmlEncode(query.ClosedIssues) ?? string.Empty);
                var result = await _httpClient
                    .GetFromJsonAsync<List<IssueWithSla>>(url)
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
                Console.WriteLine($"Query handler for '{nameof(GetIssuesWithSla)}' not found: " + ex.Message);
                throw;
            }
        }

        public async Task<WorkItemModuleSettings> GetWorkItemModuleSettings()
        {
            try
            {
                var query = new GetWorkItemModuleSettings();
                var url = _apiUrl;
                url = QueryHelpers.AddQueryString(url, nameof(query.MessageId), HttpUtility.HtmlEncode(query.MessageId) ?? string.Empty);
                var result = await _httpClient
                    .GetFromJsonAsync<WorkItemModuleSettings>(url)
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
                Console.WriteLine($"Query handler for '{nameof(GetWorkItemModuleSettings)}' not found: " + ex.Message);
                throw;
            }
        }
    }
}