namespace Bistrotic.WorkItems.Application.Queries
{
    using System.Collections.Generic;

    using Bistrotic.WorkItems.Application.ModelViews;
    using Bistrotic.WorkItems.Domain;

    public class GetWorkItemChangeHistory : WorkItemQuery<IEnumerable<WorkItemChange>>
    {
        public GetWorkItemChangeHistory()
        {
        }

        public GetWorkItemChangeHistory(WorkItemId id) : base(id)
        {
        }
    }
}