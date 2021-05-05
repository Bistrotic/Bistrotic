﻿namespace Bistrotic.Units.Domain
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Domain;
    using Bistrotic.Domain.Messages;
    using Bistrotic.Units.Domain.Events;
    using Bistrotic.Units.Domain.ValueTypes;

    public class Unit : IAggregateRoot
    {
        private readonly UnitId _unitId;

        public Unit(UnitId unitId, UnitState state)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
            _unitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
        }

        public string AggregateId => _unitId.Value;

        public string AggregateName => nameof(Unit);

        public UnitState State { get; }

        public static IEnumerable<object> AddNew(
            UnitId unitId,
            string name,
            string? description,
            out Unit unit)
        {
            unit = new Unit(unitId, new UnitState() { Name = name, Description = description });
            return new object[] { new NewUnitAdded(unitId, name, description) };
        }
    }
}