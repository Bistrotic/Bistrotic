namespace Bistrotic.Application.Queries
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    using Microsoft.Extensions.Options;

    public abstract class SettingsQueryHandler<TQuery, TSettings>
        : QueryHandler<TQuery, TSettings>
        where TQuery : QueryBase<TSettings>
        where TSettings : class
    {
        private readonly IOptions<TSettings> _options;

        protected SettingsQueryHandler(IOptions<TSettings> options)
        {
            _options = options;
        }

        public override Task<TSettings> Handle(Envelope<TQuery> envelope)
        {
            return Task.FromResult(_options.Value);
        }
    }
}