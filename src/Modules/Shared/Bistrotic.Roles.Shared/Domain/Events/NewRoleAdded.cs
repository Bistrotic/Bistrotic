namespace Bistrotic.Roles.Domain.Events
{
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class NewRoleAdded
        : RoleIdEvent
    {
        public NewRoleAdded(RoleId unitId, string name, string? description) : base(unitId)
        {
            Name = name;
            Description = description;
        }

        public string? Description { get; }
        public string Name { get; }
    }
}