namespace Bistrotic.Application.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface IRepositoryData<TState>
    {
        string CorrelationId { get; }
        IEnumerable<object> Events { get; }
        TState State { get; }
        DateTimeOffset UserDateTime { get; }
        string UserName { get; }
    }
}