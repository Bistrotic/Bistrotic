namespace Bistrotic.DataIntegrations.Application.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.SalesHistory.Common.Application.Services;

    using Microsoft.Extensions.Logging;

    [EventHandler(Event = typeof(DataIntegrationSubmittedHandler))]
    public class DataIntegrationSubmittedHandler : IEventHandler<DataIntegrationSubmitted>
    {
        private readonly ILogger<DataIntegrationSubmittedHandler> _logger;
        private readonly ISalesHistoryRepository _repository;

        public DataIntegrationSubmittedHandler(ISalesHistoryRepository repository, ILogger<DataIntegrationSubmittedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
           => Handle(new Envelope<DataIntegrationSubmitted>(envelope), cancellationToken);

        public Task Handle(Envelope<DataIntegrationSubmitted> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Data integration submission received event handler error : {e.Message}.\nMessageId={envelope.MessageId}; Id={envelope.Message.DataIntegrationId}; Name={envelope.Message.Name}");
                throw;
            }
        }
    }
}