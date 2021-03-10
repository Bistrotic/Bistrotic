namespace Bistrotic.Users.Domain.Events
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Users.Domain.ValueTypes;

    public abstract class UserIdEvent : Event<UserId>
    {
        protected UserIdEvent(UserId UserId)
            : base(UserId)
        {
        }
    }
}