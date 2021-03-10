namespace Bistrotic.Users.Application.Commands
{
    using Bistrotic.Users.Domain.ValueTypes;

    public sealed class RegisterNewUser : UserIdCommand
    {
        public RegisterNewUser(UserId UserId, string name) : base(UserId)
        {
            Name = name;
        }

        public string Name { get; }
    }
}