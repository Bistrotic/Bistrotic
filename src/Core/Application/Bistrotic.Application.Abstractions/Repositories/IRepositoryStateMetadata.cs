namespace Bistrotic.Application.Repositories
{
    using System;

    public interface IRepositoryStateMetadata
    {
        string CreatedByUser { get; }
        DateTime CreatedUtcDateTime { get; }
        string? LastModifiedByUser { get; }
        DateTime? LastModifiedUtcDateTime { get; }
    }
}