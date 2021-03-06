﻿namespace Bistrotic.Users.Application.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Domain.Contracts.Commands;
    using Bistrotic.Users.Domain.ValueTypes;

    [Command]
    public sealed class RegisterNewUser
    {
        public RegisterNewUser() => UserId = Name = string.Empty;

        public RegisterNewUser(UserId userId, string name)
            => (Name, UserId) = (name, userId);

        public string Name { get; init; }
        public string UserId { get; init; }
    }
}