﻿namespace Bistrotic.Roles.Domain
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Domain;
    using Bistrotic.Domain.Messages;
    using Bistrotic.Roles.Domain.Events;
    using Bistrotic.Roles.Domain.ValueTypes;

    public class Role : IEntity, IAggregateRoot
    {
        private readonly RoleId _unitId;

        public Role(RoleId unitId, RoleState state)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
            _unitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
        }

        public string AggregateId => _unitId.Value;

        public string AggregateName => nameof(Role);

        public RoleState State { get; }

        public static IEnumerable<IEvent> AddNew(
            RoleId unitId,
            string name,
            string? description,
            out Role unit)
        {
            unit = new Role(unitId, new RoleState() { Name = name, Description = description });
            return new IEvent[] { new NewRoleAdded(unitId, name, description) };
        }
    }
}