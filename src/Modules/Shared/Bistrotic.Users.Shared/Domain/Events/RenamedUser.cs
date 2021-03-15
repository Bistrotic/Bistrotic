﻿namespace Bistrotic.Users.Domain.Events
{
    using Bistrotic.Users.Domain.ValueTypes;

    public sealed class RenamedUser :
        UserIdEvent
    {
        public RenamedUser(UserId UserId, string oldName, string newName)
            : base(UserId) => (OldName, NewName) = (oldName, newName);

        public string NewName { get; init; }
        public string OldName { get; init; }
    }
}