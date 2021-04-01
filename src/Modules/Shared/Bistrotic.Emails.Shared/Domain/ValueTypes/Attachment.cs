namespace Bistrotic.Emails.Domain.ValueTypes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.Json.Serialization;

    [DebuggerDisplay("{Name}")]
    internal class Attachment
    {
        public string Name { get; }
        public string? Content { get; }

        [JsonIgnore]
        public IEnumerable<byte> RawContent => Content == null ? Array.Empty<byte>() : Convert.FromBase64String(Content);

        public Attachment(string name, byte[]? content)
        {
            Name = name;
            Content = content == null ? null : Convert.ToBase64String(content);
        }
        public Attachment(string name, string? base64content = null)
        {
            Name = name;
            Content = base64content;
        }
    }
}