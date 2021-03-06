﻿namespace Bistrotic.Application.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Messages;

    using Microsoft.Extensions.Options;

    public abstract class SettingsCommandHandler<TCommand, TSettings>
        : CommandHandler<TCommand>
        where TSettings : class
        where TCommand : class
    {
        private readonly IOptions<TSettings> _options;

        protected SettingsCommandHandler(IOptions<TSettings> options)
        {
            _options = options;
        }

        public override Task Handle(Envelope<TCommand> envelope, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_options.Value);
        }
    }
}