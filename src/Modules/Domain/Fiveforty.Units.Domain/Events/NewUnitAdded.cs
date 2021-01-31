namespace Fiveforty.Module.Units.Domain.Events
{
    using Fiveforty.Domain.Messages;
    using Fiveforty.Infrastructure;

    public record NewUnitAdded(string UserName, string Id, string Name, string? Description = null) :
        Event(UserName, Id, UniqueId.Create())
    {
    }
}