using System.Collections.Generic;

using Bistrotic.DataIntegrations.Domain.Events;
using Bistrotic.DataIntegrations.Domain.ValueTypes;
using Bistrotic.Domain;

namespace Bistrotic.DataIntegrations.Domain
{
    internal class DataIntegration : IAggregateRoot
    {
        private readonly string _dataIntegrationId;
        private readonly DataIntegrationState _state;

        public DataIntegration(DataIntegrationId dataIntegrationId, DataIntegrationState state)
        {
            _dataIntegrationId = dataIntegrationId;
            _state = state;
        }
        public static IReadOnlyList<object> SubmitDataIntegration(
            string dataIntegrationId,
            string name,
            string description,
            string documentName,
            string document,
            out DataIntegrationState state)
        {
            state = new DataIntegrationState();
            List<object> events = new();
            events.Add(new DataIntegrationSubmitted(dataIntegrationId, name, description, documentName, document));
            state.Apply(events);
            return events;
        }

        public string AggregateId => _dataIntegrationId;
        public string AggregateName => nameof(DataIntegration);
    }
}