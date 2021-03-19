namespace Bistrotic.Roles.Domain.Events
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Roles.Domain.ValueTypes;

    public abstract class RoleIdEvent : EventBase<RoleId>
    {
        protected RoleIdEvent(RoleId unitId)
            : base(unitId)
        {
        }
    }
}