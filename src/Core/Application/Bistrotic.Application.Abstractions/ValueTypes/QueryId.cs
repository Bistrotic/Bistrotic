namespace Bistrotic.Application.ValueTypes
{
    using Bistrotic.Domain.ValueTypes;

    public record QueryId(QueryId? Id = null) : MessageId(Id)
    {
    }
}