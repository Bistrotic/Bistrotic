using System.Collections.Generic;

namespace Bistrotic.DataIntegrations.Domain.States
{
    public interface IDataIntegrationState
    {
        IDictionary<string, object?>? Data { get; set; }
        string Description { get; set; }
        string Document { get; set; }
        string DocumentName { get; set; }
        string DocumentType { get; set; }
        string Name { get; set; }

        void Apply(IEnumerable<object> events);
    }
}