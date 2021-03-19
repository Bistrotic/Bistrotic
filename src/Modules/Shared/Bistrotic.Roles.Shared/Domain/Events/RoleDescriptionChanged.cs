namespace Bistrotic.Roles.Domain.Events
{
    using Bistrotic.Roles.Domain.ValueTypes;

    public sealed class RoleDescriptionChanged :
        RoleIdEvent
    {
        public RoleDescriptionChanged(RoleId unitId, string? description) : base(unitId)
        {
            Description = description;
        }

        public string? Description { get; }
    }
}