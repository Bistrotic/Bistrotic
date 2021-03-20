namespace Bistrotic.Infrastructure
{
    using System;
    using System.Collections.Generic;

    public class RepositoryData<TState>
        : IRepositoryData<TState>
    {
        RepositoryData(string correlationId, string userName, DateTimeOffset userDateTime, TState state, IEnumerable<object> events)
        {
            CorrelationId = correlationId;
            UserName = userName;
            UserDateTime = userDateTime;
            State = state;
            Events = events;
        }

        public string CorrelationId { get; }
        public string UserName { get; }
        public DateTimeOffset UserDateTime { get; }
        public TState State { get; }
        public IEnumerable<object> Events { get; }
    }
}