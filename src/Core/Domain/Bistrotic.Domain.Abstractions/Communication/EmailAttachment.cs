namespace Bistrotic.Domain.Communication
{
    using System;

    public class EmailAttachment
    {
        public byte[] Content { get; init; } = Array.Empty<byte>();
        public string Name { get; init; } = string.Empty;
        public int Size { get; init; }
    }
}