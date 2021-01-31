namespace Bistrotic.Domain
{
    using System;

    public interface IEntityState
    {
        string CreatedBy { get; }

        DateTime CreatedDate { get; }

        string Etag { get; }

        string Id { get; }

        string? LastModifiedBy { get; }

        DateTime? LastModifiedDate { get; }
    }
}