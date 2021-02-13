namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract class UnitIdEvent : Event<UnitId>
    {
        protected UnitIdEvent(UnitId unitId)
            : base(unitId)
        {
        }
    }
}