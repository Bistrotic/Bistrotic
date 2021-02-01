namespace Bistrotic.Units.Application.Commands
{
    using System;

    using Bistrotic.Application.Commands;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Units.Application.Abstractions.ValueTypes;

    public abstract record UnitIdCommand : Command
    {
        protected UnitIdCommand(UserName userName, UnitId UnitId, Etag? etag, MessageId? CorrelationId)
            : base(userName, UnitId, etag, CorrelationId)
        {
        }
        public UnitId UnitId
            => new UnitId(Id ?? throw new NullReferenceException(nameof(Id)));
    }
}