﻿using System.Text.Json.Serialization;

using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public abstract class MessageBase<TId> : IMessage
        where TId : BusinessId, new()
    {
        protected MessageBase()
        {
            Id = new TId();
            MessageId = new MessageId();
        }

        protected MessageBase(TId id)
        {
            Id = id ?? new TId();
            MessageId = new MessageId();
        }

        public string Id { get; init; }

        public string MessageId { get; }
    }

    public abstract class Message : IMessage

    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string? Id => null;

        public string MessageId { get; } = new MessageId();
    }
}