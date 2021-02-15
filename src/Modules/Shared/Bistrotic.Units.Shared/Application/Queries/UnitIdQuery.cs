namespace Bistrotic.Units.Application.Queries
{
    using Bistrotic.Application.Queries;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract class UnitIdQuery<TResult> : Query<UnitId, TResult>
    {
        protected UnitIdQuery()
        {
        }

        protected UnitIdQuery(UnitId unitId)
            : base(unitId)
        {
        }
    }
}