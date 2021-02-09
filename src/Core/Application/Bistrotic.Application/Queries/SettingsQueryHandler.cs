namespace Bistrotic.Application.Queries
{
    using System.Text.Json;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public abstract class SettingsQueryHandler<TQuery, TSettings>
        : QueryHandler<TQuery, TSettings>
        where TQuery : Query<TSettings>
        where TSettings : class
    {
        private readonly IOptions<TSettings> _options;

        protected SettingsQueryHandler(IOptions<TSettings> options)
        {
            _options = options;
        }

        public override Task<TSettings> Handle(TQuery query)
        {
            return Task.FromResult(_options.Value);
        }
    }
}