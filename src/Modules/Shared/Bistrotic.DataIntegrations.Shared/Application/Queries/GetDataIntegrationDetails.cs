namespace Bistrotic.DataIntegrations.Application.Queries
{
    using Bistrotic.DataIntegrations.Domain.ValueTypes;

    internal sealed class GetDataIntegrationDetails
    {
        public GetDataIntegrationDetails(DataIntegrationId dataIntegrationId)
        {
            DataIntegrationId = dataIntegrationId;
        }

        public DataIntegrationId DataIntegrationId { get; }
    }
}