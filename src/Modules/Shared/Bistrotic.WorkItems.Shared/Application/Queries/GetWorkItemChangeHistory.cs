namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.WorkItems.Domain;

    public class GetWorkItemChangeHistory
    {
        public GetWorkItemChangeHistory(WorkItemId workItemId)
        {
            WorkItemId = workItemId;
        }

        public string WorkItemId { get; }
    }
}