namespace Bistrotic.Roles.Application.Domain.Commands
{
    using Bistrotic.Roles.Application.Commands;
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class ChangeRoleDescription
    {
        public ChangeRoleDescription(RoleId unitId, string? description)
        {
            Description = description;
            UnitId = unitId;
        }

        public string? Description { get; }
        public string UnitId { get; }
    }
}