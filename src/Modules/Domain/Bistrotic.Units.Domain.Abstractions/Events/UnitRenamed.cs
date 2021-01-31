namespace Bistrotic.Module.Units.Domain.Events
{
    using Bistrotic.Domain.Messages;

    public record UnitRenamed(string UserName, string Id, string Etag, string NewName) :
        Event(UserName, Id, Etag)
    {
    }
}