﻿namespace Bistrotic.Domain
{
    public interface IAggregateRoot
    {
        string AggregateId { get; }

        string AggregateName { get; }
    }
}