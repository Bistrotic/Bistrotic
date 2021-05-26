namespace Bistrotic.FastTheme.Projections.Handlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.FastTheme.Queries;
    using Bistrotic.FastTheme.Settings;
    using Bistrotic.FastTheme.ViewModels;

    using Microsoft.Extensions.Options;

    public class GetFluentThemeSetupHandler : QueryHandler<GetFluentThemeSetup, FluentThemeSetup>
    {
        private readonly IOptions<FastThemeSettings> _settings;

        public GetFluentThemeSetupHandler(IOptions<FastThemeSettings> settings)
        {
            _settings = settings;
        }

        public override Task<FluentThemeSetup> Handle(Envelope<GetFluentThemeSetup> envelope)
        {
            return Task.FromResult(new FluentThemeSetup { BaseColor = _settings.Value.FluentBaseColor });
        }
    }
}