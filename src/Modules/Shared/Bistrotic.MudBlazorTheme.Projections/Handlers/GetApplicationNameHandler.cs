namespace Bistrotic.MudBlazorTheme.Projections.Handlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.MudBlazorTheme.Queries;
    using Bistrotic.MudBlazorTheme.Settings;

    using Microsoft.Extensions.Options;

    public class GetApplicationNameHandler : QueryHandler<GetApplicationName, string>
    {
        private readonly IOptions<MudBlazorThemeSettings> _settings;

        public GetApplicationNameHandler(IOptions<MudBlazorThemeSettings> settings)
        {
            _settings = settings;
        }

        public override Task<string> Handle(Envelope<GetApplicationName> envelope)
        {
            return Task.FromResult(_settings.Value.ApplicationName);
        }
    }
}