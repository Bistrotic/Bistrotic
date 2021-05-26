using System.Threading.Tasks;

namespace Bistrotic.MudBlazorTheme.Services
{
    public interface IApplicationNameService
    {
        Task<string> GetName();
    }
}