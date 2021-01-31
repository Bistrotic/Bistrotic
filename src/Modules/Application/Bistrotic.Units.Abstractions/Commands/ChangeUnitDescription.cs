namespace Bistrotic.Module.Units.Domain.Commands
{
    using Bistrotic.Domain.Messages;

    public record ChangeUnitDescription(string UserName, string Id, string Etag, string? Description) :
        Command(UserName, Id, Etag)
    {
    }
}