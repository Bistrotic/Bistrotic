namespace Bistrotic.Domain.ValueTypes
{
    using System.Diagnostics;

    [DebuggerDisplay("{Value}")]
    public record BusinessId(string Value)
    {
    }
}