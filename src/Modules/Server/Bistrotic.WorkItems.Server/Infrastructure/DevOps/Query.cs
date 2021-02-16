﻿namespace Bistrotic.WorkItems.Infrastructure.DevOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;

    /// <summary>
    /// The Query class. Handles all the query informations.
    /// </summary>
    public class Query : IDisposable
    {
        private readonly IEnumerable<string> _fieldNames;
        private readonly string? _query;
        private bool disposedValue;
        private WorkItemTrackingHttpClient? witClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        /// <param name="project">The DevOps query instance.</param>
        /// <param name="queryName">The DevOps project name.</param>
        public Query(Project project, string query, IEnumerable<string> fieldNames)
        {
            Project = project;
            Server = project.Server;
            _fieldNames = fieldNames;
            _query = query;
        }

        public Query(DevOpsServer server, string query, IEnumerable<string> fieldNames)
        {
            Server = server;
            _query = query;
            _fieldNames = fieldNames;
        }

        /// <summary>
        /// Gets the project.
        /// </summary>
        /// <value>The project.</value>
        /// <autogeneratedoc/>
        protected Project? Project { get; }

        protected DevOpsServer Server { get; }

        /// <summary>
        /// Gets the wit client.
        /// </summary>
        /// <value>The wit client.</value>
        /// <autogeneratedoc/>
        protected WorkItemTrackingHttpClient WitClient => witClient ??= Server.Connection.GetClient<WorkItemTrackingHttpClient>();

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the query work items.
        /// </summary>
        /// <returns>List&lt;WorkItem&gt;.</returns>
        /// <exception cref="Exception">Query not found : " + queryName.</exception>
        /// <autogeneratedoc/>
        public async Task<List<WorkItem>> GetQueryWorkItems()
        {
            var result = await WitClient
                .QueryByWiqlAsync(new Wiql { Query = _query })
                .ConfigureAwait(false);
            var ids = result.WorkItems.Select(item => item.Id).ToArray();

            // some error handling
            if (ids.Length == 0)
            {
                return new List<WorkItem>();
            }

            // get work items for the ids found in query
            return (await WitClient
                .GetWorkItemsAsync(ids, _fieldNames, result.AsOf, WorkItemExpand.Links)
                .ConfigureAwait(false))
                    .ConvertAll(p => new WorkItem(p))
;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release
        /// only unmanaged resources.
        /// </param>
        /// <autogeneratedoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && witClient != null)
                {
                    var client = witClient;
                    witClient = null;
                    client.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}