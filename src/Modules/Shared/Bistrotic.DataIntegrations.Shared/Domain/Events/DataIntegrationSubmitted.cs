namespace Bistrotic.DataIntegrations.Domain.Events
{
    using Bistrotic.DataIntegrations.Domain.ValueTypes;
    internal sealed class DataIntegrationSubmitted
    {
        public DataIntegrationSubmitted(
            DataIntegrationId dataIntegrationId,
            string name,
            string? description,
            string documentName,
            string document)
        {
            DataIntegrationId = dataIntegrationId;
            Name = name;
            Description = description;
            DocumentName = documentName;
            Document = document;
        }

        public string DataIntegrationId { get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public string DocumentName { get; init; }
        public string Document { get; init; }
    }
}