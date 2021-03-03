﻿namespace Bistrotic.WorkItems.Application.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Application.Exceptions;
    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Application.Queries;
    using Bistrotic.WorkItems.Infrastructure.DevOps;

    public class GetWorkItemChangeHistoryHandler : QueryHandler<GetWorkItemChangeHistory, IEnumerable<WorkItemChange>>
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GetWorkItemChangeHistoryHandler(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public override async Task<IEnumerable<WorkItemChange>> Handle(Envelope<GetWorkItemChangeHistory> envelope)
        {
            var settings = await _queryDispatcher
                .Dispatch<GetWorkItemModuleSettings, WorkItemModuleSettings>(
                    new Envelope<GetWorkItemModuleSettings>(new GetWorkItemModuleSettings(), envelope)
                    );
            if (string.IsNullOrWhiteSpace(settings.AzureDevOpsServerUrl) || string.IsNullOrWhiteSpace(settings.PersonalAccessToken))
            {
                throw new DevOpsServerConfigurationMissingException();
            }
            var server = new DevOpsServer(settings.AzureDevOpsServerUrl, settings.PersonalAccessToken);

            server.Connect();

            var wiCollection = new WorkItemCollection(server);
            int id = Convert.ToInt32(envelope.Message.Id);
            return (await wiCollection.GetWorkItemHistory(id))
                .Select(p => new WorkItemChange
                {
                    ChangeDate = p.ChangedDate ?? DateTime.MinValue,
                    ChangeType = ChangeType.Update,
                    UserName = p.ChangedBy
                });
        }
    }
}