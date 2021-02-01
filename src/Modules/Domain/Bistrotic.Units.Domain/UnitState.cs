namespace Bistrotic.Module.Units.Domain
{
    using Bistrotic.Domain;

    public record UnitState(string Name, string? Description) : EntityState
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}