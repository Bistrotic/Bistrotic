namespace Bistrotic.WorkItems.Infrastructure.DevOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.Graph;
    using Microsoft.VisualStudio.Services.Graph.Client;

    public class DevOpsGroup
    {
        private readonly string _groupName;
        private readonly DevOpsServer _server;
        private GraphHttpClient? _collectionClient;
        private Dictionary<string, SubjectDescriptor>? _descriptors;
        private GraphGroup? _graphGroup;

        public DevOpsGroup(DevOpsServer server, string groupName)
        {
            _server = server;
            _groupName = groupName;
        }

        public async Task<GraphGroup> GetGroup(CancellationToken? cancellationToken = null)
        {
            if (_graphGroup == null)
            {
                var graphClient = await GetGraphClient();
                SubjectDescriptor descriptor = (await GetGroupDescriptors(cancellationToken))
                    .Where(p => string.Equals(_groupName, p.Key, StringComparison.InvariantCultureIgnoreCase))
                    .Select(p => p.Value)
                    .FirstOrDefault();
                if (string.IsNullOrWhiteSpace(descriptor.Identifier))
                {
                    throw new DevOpsGroupNotFoundException(_groupName, (await GetGroupDescriptors(cancellationToken)).Keys);
                }
                _graphGroup = await graphClient.GetGroupAsync(descriptor, null, cancellationToken ?? new CancellationToken());
            }
            return _graphGroup;
        }

        public async Task<Dictionary<string, SubjectDescriptor>> GetGroupDescriptors(CancellationToken? cancellationToken = null)
        {
            if (_descriptors == null)
            {
                var graphClient = await GetGraphClient();
                var groups = await graphClient.ListGroupsAsync(null, null, null, null, cancellationToken ?? new CancellationToken());
                var descriptors = groups.GraphGroups.ToDictionary(k => k.PrincipalName, v => v.Descriptor);
                if (groups.ContinuationToken != null)
                {
                    var continuationTasks = groups.ContinuationToken.Select(p => graphClient.ListGroupsAsync(null, null, p, null, cancellationToken ?? new CancellationToken()));
                    foreach (GraphGroup group in (await Task.WhenAll(continuationTasks)).SelectMany(p => p.GraphGroups))
                    {
                        descriptors.Add(group.PrincipalName, group.Descriptor);
                    }
                }
                _descriptors = descriptors;
            }
            return _descriptors;
        }

        public async Task<IEnumerable<GraphUser>> GetMembers(CancellationToken? cancellationToken = null)
        {
            var graphClient = await GetGraphClient();
            var group = await GetGroup(cancellationToken);
            var tasks = (await graphClient.ListMembershipsAsync(
                group.Descriptor,
                GraphTraversalDirection.Down,
                null,
                null,
                cancellationToken ?? new CancellationToken()))
                .Select(p => graphClient.GetUserAsync(p.MemberDescriptor, cancellationToken));
            return await Task.WhenAll(tasks);
        }

        private async Task<GraphHttpClient> GetGraphClient()
            => _collectionClient ??= await _server.Connection.GetClientAsync<GraphHttpClient>();
    }
}