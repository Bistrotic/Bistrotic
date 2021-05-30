namespace Bistrotic.WorkItems.Application.QueryHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.WorkItems.Application.Exceptions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;
    using Bistrotic.WorkItems.Infrastructure.DevOps;

    public class GetSecurityGroupMembersHandler : QueryHandler<GetSecurityGroupMembers, IEnumerable<SecurityGroupMember>>
    {
        private readonly IQueryBus _queryDispatcher;

        public GetSecurityGroupMembersHandler(IQueryBus queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public override async Task<IEnumerable<SecurityGroupMember>> Handle(Envelope<GetSecurityGroupMembers> envelope, CancellationToken cancellationToken = default)
        {
            var settings = await _queryDispatcher
                 .Dispatch<GetWorkItemModuleSettings, WorkItemModuleSettings>(new Envelope<GetWorkItemModuleSettings>(new GetWorkItemModuleSettings(), new MessageId(), envelope), cancellationToken
                 );
            if (string.IsNullOrWhiteSpace(settings.AzureDevOpsServerUrl) || string.IsNullOrWhiteSpace(settings.PersonalAccessToken))
            {
                throw new DevOpsServerConfigurationMissingException();
            }
            if (string.IsNullOrWhiteSpace(settings.SlaGroupName))
            {
                throw new MissingSettingsException<WorkItemModuleSettings>(nameof(WorkItemModuleSettings.SlaGroupName));
            }
            var server = new DevOpsServer(settings.AzureDevOpsServerUrl, settings.PersonalAccessToken);

            server.Connect();
            var devOpsGroup = new DevOpsGroup(server, settings.SlaGroupName);
            return (await devOpsGroup.GetMembers(cancellationToken))
                .Select(p => new SecurityGroupMember
                {
                    Name = p.PrincipalName ?? string.Empty
                });
        }
    }
}