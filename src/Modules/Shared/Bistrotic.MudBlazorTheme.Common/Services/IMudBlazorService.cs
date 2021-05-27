using System.Threading.Tasks;

using Bistrotic.MudBlazorTheme.ViewModels;

namespace Bistrotic.MudBlazorTheme.Services
{
    public interface IMudBlazorThemeService
    {
        Task<MudBlazorThemeSetup> GetMudBlazorThemeSetup();
    }
}