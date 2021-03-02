namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Domain;

    public abstract class WorkItemQuery<TResult> : Query<WorkItemId, TResult>
    {
        protected WorkItemQuery()
        {
        }

        protected WorkItemQuery(WorkItemId id) : base(id)
        {
        }
    }
}