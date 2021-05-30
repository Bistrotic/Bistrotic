namespace Bistrotic.MudBlazorTheme.Projections.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.MudBlazorTheme.Queries;
    using Bistrotic.MudBlazorTheme.Settings;
    using Bistrotic.MudBlazorTheme.ViewModels;

    using Microsoft.Extensions.Options;

    public class GetMudBlazorThemeSetupHandler : QueryHandler<GetMudBlazorThemeSetup, MudBlazorThemeSetup>
    {
        private readonly IOptions<MudBlazorThemeSettings> _settings;

        public GetMudBlazorThemeSetupHandler(IOptions<MudBlazorThemeSettings> settings)
        {
            _settings = settings;
        }

        public override Task<MudBlazorThemeSetup> Handle(Envelope<GetMudBlazorThemeSetup> envelope, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new MudBlazorThemeSetup { BaseColor = _settings.Value.BaseColor });
        }
    }
}