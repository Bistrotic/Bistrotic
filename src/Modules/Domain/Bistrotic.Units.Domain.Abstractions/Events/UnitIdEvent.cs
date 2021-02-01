namespace Bistrotic.Units.Domain.Events
{
    using System;

    using Bistrotic.Domain.Messages;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract record UnitIdEvent : Event
    {
        protected UnitIdEvent(UserName userName, UnitId unitId, MessageId correlationId, Etag? etag = null)
            : base(userName, unitId, correlationId, etag)
        {
        }
        public UnitId UnitId
            => new UnitId(Id ?? throw new NullReferenceException(nameof(Id)));
    }
}