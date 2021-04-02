namespace Bistrotic.Users.Application.Domain.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Domain.Contracts.Commands;
    using Bistrotic.Users.Domain.ValueTypes;

    [Command]
    public sealed class RenameUser
    {
        public RenameUser() => UserId = OldName = NewName = string.Empty;

        public RenameUser(UserId userId, string oldName, string newName)
            => (UserId, OldName, NewName) = (userId, oldName, newName);

        public string OldName { get; init; }
        public string NewName { get; init; }
        public string UserId { get; init; }
    }
}