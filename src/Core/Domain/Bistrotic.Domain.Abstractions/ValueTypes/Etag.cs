using System.Diagnostics;

namespace Bistrotic.Domain.ValueTypes
{
    [DebuggerDisplay("{Value}")]
    public record Etag : AutoIdentifier
    {
        public Etag(MessageId? messageId = null) : base(messageId)
        {
        }
    }
}