namespace Bistrotic.Application.Repositories
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Application.Messages;

    public class RepositoryData<TState>
        : IRepositoryData<TState>
    {
        public RepositoryData(
            string correlationId,
            string causationId,
            string userName,
            DateTimeOffset userDateTime,
            TState state,
            IEnumerable<object> events)
        {
            Metadata = new()
            {
                CorrelationId = correlationId,
                CausationId = causationId,
                UserName = userName,
                UserDateTime = userDateTime
            };
            State = state;
            Events = events;
        }

        public RepositoryData(
            string correlationId,
            string causationId,
            string userName,
            DateTimeOffset userDateTime,
            IEnumerable<object> events)
            : this(
                 correlationId,
                 causationId,
                 userName,
                 userDateTime,
#pragma warning disable CS8604 // Possible null reference argument.
                 default,
#pragma warning restore CS8604 // Possible null reference argument.
                 events
                 )
        {
        }

        public RepositoryData(
            string correlationId,
            string causationId,
            string userName,
            DateTimeOffset userDateTime,
            TState state)
            : this(
                 correlationId,
                 causationId,
                 userName,
                 userDateTime,
                 state,
                 Array.Empty<object>()
                 )
        {
        }

        public RepositoryData(IEnvelope enveloppe, TState state, IEnumerable<object> events)
            : this(
                enveloppe.CorrelationId ?? enveloppe.MessageId,
                enveloppe.MessageId,
                enveloppe.UserName,
                enveloppe.UserDateTime,
                state,
                events
            )
        {
        }

        public RepositoryData(IEnvelope enveloppe, IEnumerable<object> events)
            : this(
                enveloppe.CorrelationId ?? enveloppe.MessageId,
                enveloppe.MessageId,
                enveloppe.UserName,
                enveloppe.UserDateTime,
                events
            )
        {
        }

        public RepositoryData(IEnvelope enveloppe, TState state)
            : this(
                enveloppe.CorrelationId ?? enveloppe.MessageId,
                enveloppe.MessageId,
                enveloppe.UserName,
                enveloppe.UserDateTime,
                state,
                Array.Empty<object>()
            )
        {
        }

        public IEnumerable<object> Events { get; }
        public RepositoryMetadata Metadata { get; }
        public TState State { get; }
        IRepositoryMetadata IRepositoryData<TState>.Metadata => Metadata;
    }
}