namespace Bistrotic.Emails.Application.Commands
{
    using Bistrotic.Domain.Contracts.Commands;

    using ProtoBuf;

    [Command]
    [ProtoContract(SkipConstructor = true)]
    public sealed class ReadMailbox
    {
        [ProtoMember(2)]
        public string Recipient { get; set; } = string.Empty;
    }
}