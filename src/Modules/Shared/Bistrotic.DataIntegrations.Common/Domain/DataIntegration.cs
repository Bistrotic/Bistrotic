using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.DataIntegrations.Domain.Events;
using Bistrotic.DataIntegrations.Domain.States;

namespace Bistrotic.DataIntegrations.Domain
{
    internal class DataIntegration
    {
        private readonly string _id;
        private readonly IDataIntegrationState _state;

        public DataIntegration(string id, IDataIntegrationState state)
        {
            _id = id;
            _state = state;
        }

        public Task<IEnumerable<object>> Submit(
            string name,
            string description,
            string documentName,
            string documentType,
            string document)
        {
            List<object> events = new();
            events.Add(new DataIntegrationSubmitted
            {
                DataIntegrationId = _id,
                Name = name,
                Description = description,
                DocumentName = documentName,
                DocumentType = documentType,
                Document = document
            });
            _state.Apply(events);
            return Task.FromResult<IEnumerable<object>>(events);
        }
    }
}