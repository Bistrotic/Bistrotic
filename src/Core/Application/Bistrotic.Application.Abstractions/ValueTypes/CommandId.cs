namespace Bistrotic.Application.ValueTypes
{
    using Bistrotic.Domain.ValueTypes;

    public record CommandId : MessageId
    {
        public CommandId(CommandId commandId) : base(commandId)
        {
        }
        public CommandId(string? commandId = null) : base(commandId)
        {
        }
    }
}