namespace Bistrotic.WorkItems.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.WorkItems.Domain;

    public abstract class WorkItemQuery<TResult> : Query<WokItemId, TResult>
    {
        protected WorkItemQuery()
        {
        }

        protected WorkItemQuery(WokItemId id) : base(id)
        {
        }
    }
}