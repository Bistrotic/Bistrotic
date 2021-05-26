namespace Bistrotic.FastTheme.Services
{
    using System.Threading.Tasks;

    public interface IApplicationNameService
    {
        Task<string> GetName();
    }
}