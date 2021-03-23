﻿namespace Bistrotic.Application.Messages
{
    using System;

    using Bistrotic.Domain.ValueTypes;

    public interface IEnvelope
    {
        MessageId? CausationId { get; }
        MessageId? CorrelationId { get; }
        object Message { get; }
        MessageId MessageId { get; }
        DateTimeOffset UserDateTime { get; }
        UserName UserName { get; }
    }
}