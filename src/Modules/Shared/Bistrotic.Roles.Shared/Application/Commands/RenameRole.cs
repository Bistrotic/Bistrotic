namespace Bistrotic.Roles.Application.Domain.Commands
{
    using Bistrotic.Roles.Application.Commands;
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class RenameRole :
        RoleIdCommand
    {
        public RenameRole(RoleId unitId, string newName) : base(unitId)
        {
            NewName = newName;
        }

        public string NewName { get; }
    }
}