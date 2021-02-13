namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class UnitRenamed :
        UnitIdEvent
    {
        public UnitRenamed(UnitId unitId, string newName) : base(unitId)
        {
            NewName = newName;
        }

        public string NewName { get; }
    }
}