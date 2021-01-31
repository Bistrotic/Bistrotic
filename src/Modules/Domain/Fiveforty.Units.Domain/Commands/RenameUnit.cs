namespace Fiveforty.Module.Units.Domain.Commands
{
    using Fiveforty.Domain.Messages;

    public record RenameUnit(string UserName, string Id, string Etag, string NewName) :
        Command(UserName, Id, Etag)
    {
    }
}