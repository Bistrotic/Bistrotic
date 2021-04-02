﻿namespace Bistrotic.Units.Domain.Events
{
    using Bistrotic.Units.Domain.ValueTypes;

    public sealed class NewUnitAdded
    {
        public NewUnitAdded(UnitId unitId, string name, string? description)
        {
            Name = name;
            Description = description;
            UnitId = unitId;
        }

        public string? Description { get; }
        public string Name { get; }
        public string UnitId { get; }
    }
}