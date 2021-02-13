using System.Diagnostics;

namespace Bistrotic.Domain.ValueTypes
{
    [DebuggerDisplay("{Value}")]
    public abstract class StringValue : SingleValueType<string>
    {
        protected StringValue()
        {
        }

        protected StringValue(StringValue value) : base(value)
        {
        }

        protected StringValue(string value) : base(value)
        {
        }
    }
}