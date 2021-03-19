namespace Bistrotic.Roles.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Roles.Domain.ValueTypes;

    public abstract class RoleIdQuery<TResult> : QueryBase<RoleId, TResult>
    {
        protected RoleIdQuery()
        {
        }

        protected RoleIdQuery(RoleId unitId)
            : base(unitId)
        {
        }
    }
}