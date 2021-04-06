using Bistrotic.Domain.Contracts.Events;

using ProtoBuf;

namespace Bistrotic.DataIntegrations.Contracts.Events
{
    [Event]
    [ProtoContract]
    public sealed class DataIntegrationNormalized
    {
        [ProtoMember(7)]
        public string Data { get; set; } = string.Empty;

        [ProtoMember(1)]
        public string DataIntegrationId { get; set; } = string.Empty;

        [ProtoMember(5)]
        public string Description { get; set; } = string.Empty;

        [ProtoMember(2)]
        public string Name { get; set; } = string.Empty;
    }
}