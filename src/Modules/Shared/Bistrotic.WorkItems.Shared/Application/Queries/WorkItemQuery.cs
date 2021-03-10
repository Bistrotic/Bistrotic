namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Domain;

    public abstract class WorkItemQuery<TResult> : QueryBase<WorkItemId, TResult>
    {
        protected WorkItemQuery()
        {
        }

        protected WorkItemQuery(WorkItemId id) : base(id)
        {
        }
    }
}