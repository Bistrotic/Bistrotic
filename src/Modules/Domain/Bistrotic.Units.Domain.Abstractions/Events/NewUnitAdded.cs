namespace Bistrotic.Module.Units.Domain.Events
{
    using Bistrotic.Domain.Messages;
    using Bistrotic.Infrastructure;

    public record NewUnitAdded(string UserName, string Id, string Name, string? Description = null) :
        Event(UserName, Id, UniqueId.Create())
    {
    }
}