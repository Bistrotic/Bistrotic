namespace Bistrotic.Domain.ValueTypes
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{Value}")]
    public abstract class AutoIdentifier : StringValue
    {
        protected AutoIdentifier(AutoIdentifier autoIdentifier)
        {
            Value = string.IsNullOrWhiteSpace(autoIdentifier?.Value) ? GenerateIdentifier() : autoIdentifier.Value;
        }

        protected AutoIdentifier(string id)
        {
            Value = string.IsNullOrWhiteSpace(id) ? GenerateIdentifier() : id.Trim();
        }

        protected AutoIdentifier()
        {
            Value = GenerateIdentifier();
        }

        public static string GenerateIdentifier()
                                            => Convert
                .ToBase64String(Guid.NewGuid().ToByteArray())
                .Substring(0, 22);
    }
}