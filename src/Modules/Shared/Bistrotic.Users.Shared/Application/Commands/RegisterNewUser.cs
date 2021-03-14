namespace Bistrotic.Users.Application.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Users.Domain.ValueTypes;

    [ApiCommand]
    public sealed class RegisterNewUser
    {
        public RegisterNewUser()
        {
            UserId = Name = string.Empty;
        }
        public RegisterNewUser(UserId userId, string name)
        {
            Name = name;
            UserId = userId;
        }

        public string Name { get; init; }
        public string UserId { get; init; }
    }
}