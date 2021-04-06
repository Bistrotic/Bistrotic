using System.Collections.Generic;
using System.Threading.Tasks;

using Bistrotic.DataIntegrations.Common.Domain.States;
using Bistrotic.DataIntegrations.Contracts.Events;
using Bistrotic.DataIntegrations.Contracts.ValueTypes;

namespace Bistrotic.DataIntegrations.Domain
{
    internal class DataIntegrationType
    {
        private readonly string _id;
        private readonly IDataIntegrationTypeState _state;

        public DataIntegrationType(string id, IDataIntegrationTypeState state)
        {
            _id = id;
            _state = state;
        }

        public Task<IEnumerable<object>> DefineNew(
            string name,
            string description,
            IEnumerable<DataIntegrationField> fields)
        {
            List<object> events = new();
            events.Add(new NewDataIntegrationTypeDefined
            {
                DataIntegrationTypeId = _id,
                Name = name,
                Description = description,
                Fields = fields
            });
            _state.Apply(events);
            return Task.FromResult<IEnumerable<object>>(events);
        }
    }
}