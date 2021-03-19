namespace Bistrotic.Roles.Domain
{
    using Bistrotic.Domain;

    public sealed class RoleState : EntityState
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}