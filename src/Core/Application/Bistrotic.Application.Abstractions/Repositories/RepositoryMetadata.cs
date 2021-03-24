namespace Bistrotic.Application.Repositories
{
    using System;

    public sealed class RepositoryMetadata : IRepositoryMetadata
    {
        public string CausationId { get; set; } = string.Empty;
        public string CorrelationId { get; set; } = string.Empty;
        public DateTime SystemUtcDateTime { get; set; }
        public DateTimeOffset UserDateTime { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}