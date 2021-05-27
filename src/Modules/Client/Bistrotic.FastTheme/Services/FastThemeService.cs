using System.Threading.Tasks;

using Bistrotic.Domain.ValueTypes;
using Bistrotic.FastTheme.Queries;
using Bistrotic.FastTheme.ViewModels;
using Bistrotic.Infrastructure.BlazorClient;

namespace Bistrotic.FastTheme.Services
{
    public class FastThemeService : IFastThemeService
    {
        private readonly BistroticHttpClient _httpClient;
        private FastThemeSetup? _name;

        public FastThemeService(BistroticHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<FastThemeSetup> GetFastThemeSetup()
            => _name ??= await _httpClient.Ask<GetFastThemeSetup, FastThemeSetup>(new MessageId(), new GetFastThemeSetup());
    }
}