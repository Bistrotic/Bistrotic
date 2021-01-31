namespace Bistrotic.Domain
{
    using System;

    public record Identifier
    {
        public string Value { get; init; }
            = Convert
                .ToBase64String(Guid.NewGuid().ToByteArray())
                .Substring(0, 22);
    }
}