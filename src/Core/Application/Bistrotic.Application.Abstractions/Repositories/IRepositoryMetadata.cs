namespace Bistrotic.Application.Repositories
{
    using System;
    using System.Collections.Generic;

    public interface IRepositoryMetadata
    {
        string CausationId { get; }
        string CorrelationId { get; }
        DateTime SystemUtcDateTime { get; }
        DateTimeOffset UserDateTime { get; }
        string UserName { get; }
    }
}