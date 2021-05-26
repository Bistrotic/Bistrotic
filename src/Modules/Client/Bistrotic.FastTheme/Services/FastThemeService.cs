using System.Threading.Tasks;

using Bistrotic.Domain.ValueTypes;
using Bistrotic.Infrastructure.BlazorClient;

namespace Bistrotic.FastTheme.Services
{
    public class FastThemeService : IApplicationNameService
    {
        private readonly BistroticHttpClient _httpClient;
        private string? _name;

        public FastThemeService(BistroticHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetName()
            => _name ??= await _httpClient.Ask<GetApplicationName, string>(new MessageId(), new GetApplicationName());
    }
}