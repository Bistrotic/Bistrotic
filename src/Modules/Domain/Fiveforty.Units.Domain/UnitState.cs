namespace Fiveforty.Module.Units.Domain
{
    using Fiveforty.Domain;

    public class UnitState : EntityState
    {
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}