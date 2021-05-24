namespace Bistrotic.ApplicationLayer.Projections.Handlers
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Queries;
    using Bistrotic.ApplicationLayer.Settings;
    using Bistrotic.ApplicationLayer.Queries;

    using Microsoft.Extensions.Options;

    public class GetApplicationNameHandler : QueryHandler<GetApplicationName, string>
    {
        private readonly IOptions<ApplicationLayerSettings> _settings;

        public GetApplicationNameHandler(IOptions<ApplicationLayerSettings> settings)
        {
            _settings = settings;
        }

        public override Task<string> Handle(Envelope<GetApplicationName> envelope)
        {
            return Task.FromResult(_settings.Value.ApplicationName);
        }
    }
}