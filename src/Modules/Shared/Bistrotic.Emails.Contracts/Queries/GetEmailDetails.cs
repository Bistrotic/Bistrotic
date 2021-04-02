namespace Bistrotic.Emails.Application.Queries
{
    using Bistrotic.Domain.Contracts.Projections;

    using ProtoBuf;

    [ProtoContract]
    [Query]
    public sealed class GetEmailDetails
    {
        [ProtoMember(1)]
        public string EmailId { get; set; }
    }
}