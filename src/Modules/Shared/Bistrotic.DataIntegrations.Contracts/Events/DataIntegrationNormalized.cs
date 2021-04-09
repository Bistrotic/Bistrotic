using System.Collections.Generic;

using Bistrotic.Domain.Contracts.Events;

using ProtoBuf;

namespace Bistrotic.DataIntegrations.Contracts.Events
{
    [Event]
    [ProtoContract]
    public sealed class DataIntegrationNormalized
    {
        [ProtoMember(5)]
        public IDictionary<string, object?> Data { get; set; } = new Dictionary<string, object?>();

        [ProtoMember(1)]
        public string DataIntegrationId { get; set; } = string.Empty;

        [ProtoMember(3)]
        public string Description { get; set; } = string.Empty;

        [ProtoMember(2)]
        public string Name { get; set; } = string.Empty;
    }
}