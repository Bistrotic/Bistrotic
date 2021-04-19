﻿namespace Bistrotic.DataIntegrations.Application.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Contracts.Commands;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.Domain.ValueTypes;

    using Microsoft.Extensions.Logging;

    [EventHandler(Event = typeof(DataIntegrationSubmitted))]
    public class DataIntegrationSubmittedHandler : IEventHandler<DataIntegrationSubmitted>
    {
        private readonly ICommandBus _commandBus;
        private readonly ILogger<DataIntegrationSubmittedHandler> _logger;

        public DataIntegrationSubmittedHandler(ICommandBus commandBus, ILogger<DataIntegrationSubmittedHandler> logger)
        {
            _commandBus = commandBus;
            _logger = logger;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
           => Handle(new Envelope<DataIntegrationSubmitted>(envelope), cancellationToken);

        public async Task Handle(Envelope<DataIntegrationSubmitted> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                await _commandBus.Send(new Envelope<NormalizeDataIntegration>(
                    new NormalizeDataIntegration
                    {
                        DataIntegrationId = envelope.Message.DataIntegrationId
                    }, new MessageId(), envelope), cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Data integration submitted event handler error : {e.Message}.\nMessageId={envelope.MessageId}; DataIntegrationId={envelope.Message.DataIntegrationId}.");
                throw;
            }
        }
    }
}