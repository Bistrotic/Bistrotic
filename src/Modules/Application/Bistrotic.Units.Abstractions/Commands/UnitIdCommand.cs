namespace Bistrotic.Units.Application.Commands
{
    using System;

    using Bistrotic.Application.Commands;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract record UnitIdCommand : Command
    {
        protected UnitIdCommand(UnitId UnitId)
            : base(UnitId)
        {
        }
        public UnitId UnitId
            => new UnitId(Id ?? throw new NullReferenceException(nameof(Id)));
    }
}