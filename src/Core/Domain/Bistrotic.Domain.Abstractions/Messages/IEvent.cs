using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Domain.Messages
{
    public interface IEvent : IMessage
    {
        Etag? Etag { get; }
    }
}