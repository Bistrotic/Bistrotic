namespace Bistrotic.Roles.Application.Commands
{
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class AddNewRole : RoleIdCommand
    {
        public AddNewRole(RoleId unitId, string name, string? description) : base(unitId)
        {
            Name = name;
            Description = description;
        }

        public string? Description { get; }
        public string Name { get; }
    }
}
