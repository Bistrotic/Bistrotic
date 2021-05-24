namespace Bistrotic.ApplicationLayer.Queries
{
    using Bistrotic.Domain.Contracts.Projections;

    using ProtoBuf;

    [ProtoContract]
    [Query]
    public sealed class GetApplicationName
    {
    }
}