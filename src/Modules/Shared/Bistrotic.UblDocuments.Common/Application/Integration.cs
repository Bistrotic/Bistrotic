namespace Bistrotic.UblDocuments.Application
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Integration
    {
        [Key]
        public string MessageId { get; set; } = string.Empty;
        public string IntegrationId { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Data { get; set; } = string.Empty;
        public DateTimeOffset? IntegrationDate { get; set; }
        public DateTimeOffset ReceivedDate { get; set; }
    }
}