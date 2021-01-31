namespace Bistrotic.Domain
{
    public interface IAggregateRoot
    {
        string AggregateName { get; }
    }
}