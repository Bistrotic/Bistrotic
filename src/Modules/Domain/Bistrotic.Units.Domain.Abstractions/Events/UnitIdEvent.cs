namespace Bistrotic.Units.Domain.Events
{
    using System;

    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract record UnitIdEvent : Event
    {
        protected UnitIdEvent(UnitId unitId)
            : base(unitId)
        {
        }
        public UnitId UnitId
            => new UnitId(Id ?? throw new NullReferenceException(nameof(Id)));
    }
}