namespace Bistrotic.Roles.Application.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Roles.Domain.ValueTypes;

    public abstract class RoleIdCommand : Command<RoleId>
    {
        protected RoleIdCommand(RoleId unitId)
            : base(unitId)
        {
        }
    }
}