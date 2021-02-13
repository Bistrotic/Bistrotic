using System;
using System.Text.Json.Serialization;

using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public abstract class Message<TId> : IMessage
        where TId : BusinessId
    {
        protected Message(TId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public TId Id { get; }

        public MessageId MessageId { get; } = new MessageId();
        BusinessId? IMessage.Id => Id;
    }

    public abstract class Message : IMessage

    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public BusinessId? Id => null;

        public MessageId MessageId { get; } = new MessageId();
    }
}