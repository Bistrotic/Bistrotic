namespace Bistrotic.Infrastructure.CodeGeneration.Tests.Fixtures
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Domain.ValueTypes;
    using Bistrotic.Infrastructure.CodeGeneration.Attributes;

    [ApiCommand]
    public class TestCommand : ICommand
    {
        public string? Id { get; }
        public string MessageId { get; } = new MessageId();
    }
}