namespace Fiveforty.Infrastructure
{
    using System;
    using System.Collections.Generic;

    public record RepositoryData<TState>
        (string CorrelationId, string UserName, DateTimeOffset UserDateTime, TState State, IEnumerable<object> Events)
        : IRepositoryData<TState>
    {
    }
}