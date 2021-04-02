namespace Bistrotic.Roles.Application.Commands
{
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class AddNewRole
    {
        public AddNewRole(RoleId unitId, string name, string? description)
        {
            Name = name;
            Description = description;
            UnitId = unitId;
        }

        public string? Description { get; }
        public string Name { get; }
        public string UnitId { get; }
    }
}