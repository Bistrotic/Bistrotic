using System.Threading.Tasks;

namespace Bistrotic.MudBlazorTheme.Services
{
    public interface IMudBlazorThemeService
    {
        Task<string> GetMudBlazorThemeSetup();
    }
}