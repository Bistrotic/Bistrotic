using System.Diagnostics;

namespace Bistrotic.Domain.ValueTypes
{
    [DebuggerDisplay("{Value}")]
    public record MessageId : AutoIdentifier
    {
        public MessageId(MessageId? messageId = null) : base(messageId)
        {
        }
    }
}