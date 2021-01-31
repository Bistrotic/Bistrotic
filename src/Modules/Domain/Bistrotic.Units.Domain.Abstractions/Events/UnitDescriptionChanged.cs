namespace Bistrotic.Module.Units.Domain.Events
{
    using Bistrotic.Domain.Messages;

    public record UnitDescriptionChanged(string UserName, string Id, string Etag, string? Description) :
        Event(UserName, Id, Etag)
    {
    }
}