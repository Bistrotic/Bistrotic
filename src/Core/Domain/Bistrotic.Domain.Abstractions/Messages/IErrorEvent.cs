namespace Bistrotic.Domain.Messages
{
    public interface IErrorEvent
    {
        string ErrorMessage { get; }
    }
}