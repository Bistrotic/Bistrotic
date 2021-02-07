using System.Diagnostics;

namespace Bistrotic.Domain.ValueTypes
{
    [DebuggerDisplay("{Value}")]
    public record MessageId : AutoIdentifier
    {
        public MessageId(MessageId messageId) : base(messageId)
        {
        }
        public MessageId(string? id = null) : base(id)
        {
        }
    }
}