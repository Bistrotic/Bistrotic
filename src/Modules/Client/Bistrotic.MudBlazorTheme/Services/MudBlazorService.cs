using System.Threading.Tasks;

using Bistrotic.Domain.ValueTypes;
using Bistrotic.Infrastructure.BlazorClient;
using Bistrotic.MudBlazorTheme.Queries;
using Bistrotic.MudBlazorTheme.ViewModels;

namespace Bistrotic.MudBlazorTheme.Services
{
    public class MudBlazorThemeService : IMudBlazorThemeService
    {
        private readonly BistroticHttpClient _httpClient;
        private MudBlazorThemeSetup? _setup;

        public MudBlazorThemeService(BistroticHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MudBlazorThemeSetup> GetMudBlazorThemeSetup()
            => _setup ??= await _httpClient.Ask<GetMudBlazorThemeSetup, MudBlazorThemeSetup>(new MessageId(), new GetMudBlazorThemeSetup());
    }
}