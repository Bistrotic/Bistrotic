namespace Bistrotic.Emails.Contracts.ValueTypes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using ProtoBuf;

    [DebuggerDisplay("{Name}")]
    [ProtoContract]
    public class Attachment
    {
        [ProtoMember(2)]
        public string Content { get; set; }

        [ProtoMember(1)]
        public string Name { get; set; }

        public IEnumerable<byte> RawContent => Content == null ? Array.Empty<byte>() : Convert.FromBase64String(Content);
    }
}