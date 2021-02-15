namespace Bistrotic.Units.Application.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Units.Domain.ValueTypes;

    public abstract class UnitIdCommand : Command<UnitId>
    {
        protected UnitIdCommand(UnitId unitId)
            : base(unitId)
        {
        }
    }
}