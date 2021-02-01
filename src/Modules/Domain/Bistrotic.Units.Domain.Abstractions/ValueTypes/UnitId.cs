using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Units.Domain.ValueTypes
{
    public record UnitId(string Value) : BusinessId(Value)
    {
    }
}