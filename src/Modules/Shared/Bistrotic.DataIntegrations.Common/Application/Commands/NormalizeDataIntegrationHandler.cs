namespace Bistrotic.DataIntegrations.Application.Commands
{
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Helpers;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.DataIntegrations.Contracts.Commands;
    using Bistrotic.DataIntegrations.Domain;
    using Bistrotic.DataIntegrations.Domain.States;

    using Microsoft.Extensions.Logging;

    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    [CommandHandler(Command = typeof(NormalizeDataIntegration))]
    public class NormalizeDataIntegrationHandler : ICommandHandler<NormalizeDataIntegration>
    {
        private readonly ILogger<NormalizeDataIntegrationHandler> _logger;
        private readonly IRepository<IDataIntegrationState> _repository;

        public NormalizeDataIntegrationHandler(IRepository<IDataIntegrationState> repository, ILogger<NormalizeDataIntegrationHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task Handle(Envelope<NormalizeDataIntegration> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                var id = envelope.Message.DataIntegrationId;
                var state = await _repository.GetState(id, cancellationToken);
                var integration = new DataIntegration(id, state);
                var command = envelope.Message;
                var events = await integration.Normalize();
                await _repository.AddStateLog(id, envelope.ToMetadata(), events, cancellationToken);
                await _repository.SetState(id, envelope.ToMetadata(), state, cancellationToken);
                await _repository.Publish(events.Select(p => new Envelope(p, new Bistrotic.Domain.ValueTypes.MessageId(), envelope)).ToList(), cancellationToken);
                await _repository.Save(cancellationToken);
            }
            catch (Exception)
            {
                _logger.LogError($"Data integration normalization error : Id='{envelope.Message.DataIntegrationId}', MessageId='{envelope.MessageId}'.");
                throw;
            }
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<NormalizeDataIntegration>(envelope), cancellationToken);
    }
}