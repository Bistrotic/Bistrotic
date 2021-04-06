namespace Bistrotic.DataIntegrations.Contracts.Commands
{
    using Bistrotic.Domain.Contracts.Commands;

    using ProtoBuf;

    [Command]
    [ProtoContract(SkipConstructor = true)]
    public sealed class NormalizeDataIntegration
    {
        [ProtoMember(1)]
        public string DataIntegrationId { get; set; } = string.Empty;
    }
}