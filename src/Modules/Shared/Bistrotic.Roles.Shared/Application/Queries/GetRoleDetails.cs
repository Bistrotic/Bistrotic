namespace Bistrotic.Roles.Application.Queries
{
    using Bistrotic.Roles.Application.ModelViews;
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class GetRoleDetails
        : RoleIdQuery<RoleDetailedInformations>
    {
        public GetRoleDetails(RoleId unitId) : base(unitId)
        {
        }
    }
}