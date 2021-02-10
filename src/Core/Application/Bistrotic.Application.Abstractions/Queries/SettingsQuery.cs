namespace Bistrotic.Application.Queries
{
    public record SettingsQuery<TResult>(string Domain)
        : Query<TResult>(Domain)
    {
    }
}