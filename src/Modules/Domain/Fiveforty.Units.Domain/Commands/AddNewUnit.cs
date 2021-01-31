namespace Fiveforty.Module.Units.Domain.Commands
{
    using Fiveforty.Domain.Messages;

    public record AddNewUnit(string UserName, string Id, string Name, string? Description = null) :
        Command(UserName, Id, null)
    {
    }
}