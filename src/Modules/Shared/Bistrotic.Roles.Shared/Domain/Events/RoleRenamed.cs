namespace Bistrotic.Roles.Domain.Events
{
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class RoleRenamed :
        RoleIdEvent
    {
        public RoleRenamed(RoleId unitId, string newName) : base(unitId)
        {
            NewName = newName;
        }

        public string NewName { get; }
    }
}