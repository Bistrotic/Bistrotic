namespace Bistrotic.DataIntegrations.Application.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.DataIntegrations.Domain.ValueTypes;

    [Command]
    internal sealed class SubmitDataIntegration
    {
        public SubmitDataIntegration(
            DataIntegrationId dataIntegrationId,
            string name,
            string description,
            string documentName,
            string document)
        {
            Name = name;
            Document = document;
            Description = description;
            DataIntegrationId = dataIntegrationId;
            DocumentName = documentName;
        }

        public SubmitDataIntegration(
            string name,
            string description,
            string documentName,
            string document)
            : this(
                 new DataIntegrationId(name, documentName),
                 name,
                 description,
                 documentName,
                 document)
        {
        }

        public string Name { get; init; }

        /// <summary>
        /// Json document containing the data to integrate
        /// </summary>
        public string Document { get; init; }
        public string Description { get; init; }
        public string DataIntegrationId { get; init; }
        public string DocumentName { get; }
    }
}