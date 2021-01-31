namespace Fiveforty.Module.Units.Domain.Events
{
    using Fiveforty.Domain.Messages;

    public record UnitRenamed(string UserName, string Id, string Etag, string NewName) :
        Event(UserName, Id, Etag)
    {
    }
}