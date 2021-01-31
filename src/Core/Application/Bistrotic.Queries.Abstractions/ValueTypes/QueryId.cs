namespace Bistrotic.Queries
{
    using System;

    public record QueryId
    {
        public QueryId(string? value = null)
        {
            Value = value ?? Convert
                .ToBase64String(Guid.NewGuid().ToByteArray())
                .Substring(0, 22);
        }
        public string Value { get; init; }
    }
}