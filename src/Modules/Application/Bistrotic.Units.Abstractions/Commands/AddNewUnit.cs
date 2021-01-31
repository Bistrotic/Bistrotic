namespace Bistrotic.Units.Application.Commands
{
    using Bistrotic.Commands;

    public record AddNewUnit(string UserName, string Id, string Name, string? Description = null) :
        Command(UserName, Id, null)
    {
    }
}