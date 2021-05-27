namespace Bistrotic.FastTheme.Services
{
    using System.Threading.Tasks;

    using Bistrotic.FastTheme.ViewModels;

    public interface IFastThemeService
    {
        Task<FastThemeSetup> GetFastThemeSetup();
    }
}