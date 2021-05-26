using System.Threading.Tasks;

using Bistrotic.Domain.ValueTypes;
using Bistrotic.Infrastructure.BlazorClient;

namespace Bistrotic.MudBlazorTheme.Services
{
    public class MudBlazorThemeService : IApplicationNameService
    {
        private readonly BistroticHttpClient _httpClient;
        private string? _name;

        public MudBlazorThemeService(BistroticHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetName()
            => _name ??= await _httpClient.Ask<GetApplicationName, string>(new MessageId(), new GetApplicationName());
    }
}