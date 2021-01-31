using System;
using System.Diagnostics;

namespace Bistrotic.Domain.ValueTypes
{
    [DebuggerDisplay("{Value}")]
    public record UserName
    {
        public UserName(string value)
        {
            Value = value?.Trim() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(value) || Value.Length > DomainConstants.MAX_USER_NAME_LENGTH)
                throw new ArgumentException($"User name not defined or has more than {DomainConstants.MAX_USER_NAME_LENGTH} characters. Name : '{Value}'.", nameof(value));
        }
        public string Value { get; }
    }
}