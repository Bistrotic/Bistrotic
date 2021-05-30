namespace Bistrotic.WorkItems.Application.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.WorkItems.Application.Exceptions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;
    using Bistrotic.WorkItems.Domain;
    using Bistrotic.WorkItems.Infrastructure.DevOps;

    public class GetWorkItemChangeHistoryHandler : QueryHandler<GetWorkItemChangeHistory, IEnumerable<WorkItemChange>>
    {
        private readonly IQueryBus _queryDispatcher;

        public GetWorkItemChangeHistoryHandler(IQueryBus queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public override async Task<IEnumerable<WorkItemChange>> Handle(Envelope<GetWorkItemChangeHistory> envelope, CancellationToken cancellationToken = default)
        {
            var settings = await _queryDispatcher
                .Dispatch<GetWorkItemModuleSettings, WorkItemModuleSettings>(
                    new Envelope<GetWorkItemModuleSettings>(new GetWorkItemModuleSettings(), new MessageId(), envelope), cancellationToken
                    );
            if (string.IsNullOrWhiteSpace(settings.AzureDevOpsServerUrl) || string.IsNullOrWhiteSpace(settings.PersonalAccessToken))
            {
                throw new DevOpsServerConfigurationMissingException();
            }
            var server = new DevOpsServer(settings.AzureDevOpsServerUrl, settings.PersonalAccessToken);

            server.Connect();

            var wiCollection = new WorkItemCollection(server);
            int id = Convert.ToInt32(envelope.Message.WorkItemId, CultureInfo.InvariantCulture);
            return (await wiCollection.GetWorkItemHistory(id, cancellationToken))
                .Select(p => new WorkItemChange
                {
                    ChangeDate = p.ChangedDate ?? DateTime.MinValue,
                    ChangeType = ChangeType.Update,
                    UserName = p.ChangedBy,
                    State = p.State switch
                    {
                        "New" => WorkItemState.New,
                        "Active" => WorkItemState.Active,
                        "Closed" => WorkItemState.Closed,
                        "Resolved" => WorkItemState.Resolved,
                        _ => WorkItemState.Active
                    }
                });
        }
    }
}