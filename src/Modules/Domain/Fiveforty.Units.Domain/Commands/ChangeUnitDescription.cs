namespace Fiveforty.Module.Units.Domain.Commands
{
    using Fiveforty.Domain.Messages;

    public record ChangeUnitDescription(string UserName, string Id, string Etag, string? Description) :
        Command(UserName, Id, Etag)
    {
    }
}