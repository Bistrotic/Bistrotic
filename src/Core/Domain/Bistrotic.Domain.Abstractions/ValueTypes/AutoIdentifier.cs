namespace Bistrotic.Domain.ValueTypes
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{Value}")]
    public record AutoIdentifier
    {
        public AutoIdentifier()
        {
            // Compiler complains on the Value property if this default constructor is removed :
            // CS8618 Non-nullable field must contain a non-null value when exiting constructor.
            // Consider declaring as nullable.
            Value = GenerateIdentifier();
        }

        public static string GenerateIdentifier()
            => Convert
                .ToBase64String(Guid.NewGuid().ToByteArray())
                .Substring(0, 22);

        public AutoIdentifier(AutoIdentifier autoIdentifier)
        {
            Value = autoIdentifier.Value ?? GenerateIdentifier();
        }
        public AutoIdentifier(string? id)
        {
            Value = string.IsNullOrWhiteSpace(id) ? GenerateIdentifier() : id.Trim();
        }
        public string Value { get; init; }

        public static implicit operator string(AutoIdentifier id) => id.Value;
    }
}