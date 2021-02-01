namespace Bistrotic.Units.Application.Queries
{
    using System;

    using Bistrotic.Application.Queries;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract record UnitIdQuery<TResult> : Query<TResult>
    {
        protected UnitIdQuery(UnitId UnitId)
            : base(UnitId)
        {
        }
        public UnitId UnitId
            => new UnitId(Id ?? throw new NullReferenceException(nameof(Id)));
    }
}