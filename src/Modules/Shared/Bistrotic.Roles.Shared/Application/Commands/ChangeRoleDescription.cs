namespace Bistrotic.Roles.Application.Domain.Commands
{
    using Bistrotic.Roles.Application.Commands;
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class ChangeRoleDescription : RoleIdCommand
    {
        public ChangeRoleDescription(RoleId unitId, string? description) : base(unitId)
        {
            Description = description;
        }

        public string? Description { get; }
    }
}