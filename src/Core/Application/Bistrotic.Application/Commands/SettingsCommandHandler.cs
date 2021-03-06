namespace Bistrotic.Application.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    using Microsoft.Extensions.Options;

    public abstract class SettingsCommandHandler<TCommand, TSettings>
        : CommandHandler<TCommand>
        where TCommand : CommandBase
        where TSettings : class
    {
        private readonly IOptions<TSettings> _options;

        protected SettingsCommandHandler(IOptions<TSettings> options)
        {
            _options = options;
        }

        public override Task Handle(Envelope<TCommand> envelope)
        {
            return Task.FromResult(_options.Value);
        }
    }
}