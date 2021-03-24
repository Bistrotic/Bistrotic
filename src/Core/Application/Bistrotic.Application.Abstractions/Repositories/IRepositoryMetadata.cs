namespace Bistrotic.Application.Repositories
{
    using System;

    public interface IRepositoryMetadata
    {
        string CausationId { get; }
        string CorrelationId { get; }
        DateTimeOffset UserDateTime { get; }
        string UserName { get; }
    }
}