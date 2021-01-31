namespace Bistrotic.Domain
{
    public interface IEvent
    {
        string? Etag { get; }
        string EventId { get; }
        string? Id { get; }
        string UserName { get; }
    }
}