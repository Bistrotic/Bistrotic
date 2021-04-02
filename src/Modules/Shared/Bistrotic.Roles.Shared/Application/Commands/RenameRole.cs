namespace Bistrotic.Roles.Application.Domain.Commands
{
    using Bistrotic.Roles.Application.Commands;
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class RenameRole
    {
        public RenameRole(RoleId unitId, string newName)
        {
            UnitId = unitId;
            NewName = newName;
        }

        public RoleId UnitId { get; }
        public string NewName { get; }
    }
}