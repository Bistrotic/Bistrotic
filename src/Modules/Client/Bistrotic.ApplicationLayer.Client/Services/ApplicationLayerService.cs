using System.Threading.Tasks;

using Bistrotic.ApplicationLayer.Queries;
using Bistrotic.Domain.ValueTypes;
using Bistrotic.Infrastructure.BlazorClient;

namespace Bistrotic.ApplicationLayer.Services
{
    public class ApplicationLayerService : IApplicationNameService
    {
        private readonly BistroticHttpClient _httpClient;
        private string? _name;

        public ApplicationLayerService(BistroticHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetName()
            => _name ??= await _httpClient.Ask<GetApplicationName, string>(new MessageId(), new GetApplicationName());
    }
}