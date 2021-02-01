namespace Bistrotic.Module.Units.Domain
{
    using System;

    using Bistrotic.Domain;
    using Bistrotic.Units.Domain.ValueTypes;

    public class Unit : IEntity, IAggregateRoot
    {
        private readonly UnitState _state;
        private readonly UnitId _unitId;

        public Unit(UnitId unitId, UnitState state)
        {
            _state = state ?? throw new ArgumentNullException(nameof(state));
            _unitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
        }

        public Unit(UnitId unitId, string name, string? description)
        {
            _unitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
            _state = new UnitState(name, description);
        }

        public string AggregateId => _unitId.Value;
        public string AggregateName => nameof(Unit);
    }
}