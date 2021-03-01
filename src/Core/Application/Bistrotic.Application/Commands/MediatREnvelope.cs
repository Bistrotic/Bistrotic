using System;

using Bistrotic.Application.Messages;
using Bistrotic.Domain.Messages;

using MediatR;

namespace Bistrotic.Application.Queries
{
    public sealed class MediatREnvelope<TMessage> : Envelope<TMessage>, INotification, IEquatable<MediatREnvelope<TMessage>>
        where TMessage : IMessage
    {
        public MediatREnvelope(TMessage message, Domain.ValueTypes.UserName userName, Domain.ValueTypes.MessageId? correlationId = null) : base(message, userName, correlationId)
        {
        }

        public MediatREnvelope(TMessage message, IEnvelope parent) : base(message, parent)
        {
        }

        public MediatREnvelope(IEnvelope envelope) : base(envelope)
        {
        }

        public bool Equals(MediatREnvelope<TMessage>? other)
            => other != null && other.Message.MessageId == Message.MessageId;
    }
}