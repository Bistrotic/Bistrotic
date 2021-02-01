using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Units.Application.Abstractions.ValueTypes
{
    public record UnitId(string Value) : BusinessId(Value)
    {
    }
}