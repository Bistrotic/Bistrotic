namespace Fiveforty.Module.Units.Domain.Events
{
    using Fiveforty.Domain.Messages;

    public record UnitDescriptionChanged(string UserName, string Id, string Etag, string? Description) :
        Event(UserName, Id, Etag)
    {
    }
}