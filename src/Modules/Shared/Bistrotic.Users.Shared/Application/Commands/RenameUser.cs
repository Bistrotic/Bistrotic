namespace Bistrotic.Users.Application.Domain.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Users.Domain.ValueTypes;

    [ApiCommand]
    public sealed class RenameUser
    {
        public RenameUser()
        {
            UserId = OldName = NewName = string.Empty;
        }
        public RenameUser(UserId userId, string oldName, string newName)
        {
            OldName = oldName;
            NewName = newName;
            UserId = userId;
        }

        public string OldName { get; init; }
        public string NewName { get; init; }
        public string UserId { get; init; }
    }
}