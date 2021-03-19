namespace Bistrotic.Roles.Application.Queries
{
    using Bistrotic.Roles.Application.ModelViews;
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class GetRoleSummaryInformations : RoleIdQuery<RoleSummaryInformations>
    {
        public GetRoleSummaryInformations(RoleId unitId) : base(unitId)
        {
        }
    }
}