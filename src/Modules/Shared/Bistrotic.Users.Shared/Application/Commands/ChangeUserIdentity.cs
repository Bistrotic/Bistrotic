namespace Bistrotic.Users.Application.Commands
{
    using System;

    using Bistrotic.Application.Commands;
    using Bistrotic.Users.Domain.ValueTypes;

    [ApiCommand]
    public record ChangeUserIdentity
    {
        public ChangeUserIdentity(
            UserId userId,
            string? oldFirstName = null,
            string? oldLastName = null,
            DateTime? oldBirthDate = null,
            string? newFirstName = null,
            string? newLastName = null,
            DateTime? newBirthDate = null
            )
        {
            UserId = userId;
            OldFirstName = oldFirstName;
            OldLastName = oldLastName;
            OldBirthDate = oldBirthDate;
            NewFirstName = newFirstName;
            NewLastName = newLastName;
            NewBirthDate = newBirthDate;
        }

        public string UserId { get; init; }
        public string? OldFirstName { get; init; }
        public string? OldLastName { get; init; }
        public DateTime? OldBirthDate { get; init; }
        public string? NewFirstName { get; init; }
        public string? NewLastName { get; init; }
        public DateTime? NewBirthDate { get; init; }
    }
}