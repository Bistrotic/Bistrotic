using System.ComponentModel.DataAnnotations;

namespace Bistrotic.UblInvoices.Application
{
    public class UblIntegration
    {
        [Key]
        public string MessageId { get; set; } = string.Empty;
        public string IntegrationId { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Data { get; set; } = string.Empty;
    }
}