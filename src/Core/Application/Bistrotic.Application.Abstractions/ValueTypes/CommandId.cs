namespace Bistrotic.Application.ValueTypes
{
    using Bistrotic.Domain.ValueTypes;

    public record CommandId(CommandId? Id = null) : MessageId(Id)
    {
    }
}