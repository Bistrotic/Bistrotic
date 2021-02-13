namespace Bistrotic.Domain.ValueTypes
{
    using System.Diagnostics;

    [DebuggerDisplay("{Value}")]
    public abstract record BusinessId(string Value)
    {
        public static implicit operator string(BusinessId id) => id.Value;
    }
}