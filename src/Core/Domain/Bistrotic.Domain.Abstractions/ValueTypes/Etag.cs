using System.Diagnostics;

namespace Bistrotic.Domain.ValueTypes
{
    [DebuggerDisplay("{Value}")]
    public record Etag : AutoIdentifier
    {
        public Etag(MessageId messageId) : base(messageId)
        {
        }
        public Etag(string? id = null) : base(id)
        {
        }
    }
}