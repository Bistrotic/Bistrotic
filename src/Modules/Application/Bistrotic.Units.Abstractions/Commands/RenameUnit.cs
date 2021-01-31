namespace Bistrotic.Module.Units.Domain.Commands
{
    using Bistrotic.Domain.Messages;

    public record RenameUnit(string UserName, string Id, string Etag, string NewName) :
        Command(UserName, Id, Etag)
    {
    }
}