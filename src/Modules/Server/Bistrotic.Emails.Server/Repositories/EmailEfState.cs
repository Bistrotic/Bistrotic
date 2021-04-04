namespace Bistrotic.Emails.Repositories
{
    using System;

    using Bistrotic.Application.Repositories;
    using Bistrotic.Emails.Domain.States;
    using Bistrotic.Infrastructure.EfCore.Repositories;

    public sealed class EmailEfState :
        EmailState,
        IRepositoryStateMetadata,
        IRepositoryDbSet
    {
        public string CreatedByUser { get; set; } = string.Empty;
        public DateTime CreatedUtcDateTime { get; set; }
        public string Id { get; set; } = string.Empty;
        public int IdHash { get; }
        public string? LastModifiedByUser { get; set; }
        public DateTime? LastModifiedUtcDateTime { get; set; }
    }
}