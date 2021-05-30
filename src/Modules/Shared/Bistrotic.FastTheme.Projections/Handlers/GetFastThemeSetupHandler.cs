namespace Bistrotic.FastTheme.Projections.Handlers
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.FastTheme.Queries;
    using Bistrotic.FastTheme.Settings;
    using Bistrotic.FastTheme.ViewModels;

    using Microsoft.Extensions.Options;

    public class GetFastThemeSetupHandler : QueryHandler<GetFastThemeSetup, FastThemeSetup>
    {
        private readonly IOptions<FastThemeSettings> _settings;

        public GetFastThemeSetupHandler(IOptions<FastThemeSettings> settings)
        {
            _settings = settings;
        }

        public override Task<FastThemeSetup> Handle(Envelope<GetFastThemeSetup> envelope, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new FastThemeSetup { BaseColor = _settings.Value.FastBaseColor });
        }
    }
}