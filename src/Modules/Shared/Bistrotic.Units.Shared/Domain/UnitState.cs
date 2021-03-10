namespace Bistrotic.Units.Domain
{
    using Bistrotic.Domain;

    public sealed class UnitState : EntityState
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}