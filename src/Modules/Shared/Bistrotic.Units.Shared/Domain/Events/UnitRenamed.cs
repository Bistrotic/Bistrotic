namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class UnitRenamed
    {
        public UnitRenamed(UnitId unitId, string newName)
        {
            NewName = newName;
            UnitId = unitId;
        }

        public string NewName { get; }
        public string UnitId { get; }
    }
}