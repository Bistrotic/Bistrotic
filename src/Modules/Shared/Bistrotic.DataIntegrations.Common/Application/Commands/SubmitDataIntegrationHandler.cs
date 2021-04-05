namespace Bistrotic.DataIntegrations.Application.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.DataIntegrations.Domain;
    using Bistrotic.DataIntegrations.Domain.States;

    using Microsoft.Extensions.Logging;

    [CommandHandler(Command = typeof(SubmitDataIntegration))]
    public class SubmitDataIntegrationHandler : ICommandHandler<SubmitDataIntegration>
    {
        private readonly ILogger<SubmitDataIntegrationHandler> _logger;
        private readonly IRepository<IDataIntegrationState> _repository;

        public SubmitDataIntegrationHandler(IRepository<IDataIntegrationState> repository, ILogger<SubmitDataIntegrationHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task Handle(Envelope<SubmitDataIntegration> envelope, CancellationToken cancellationToken = default)
        {
            try
            {
                var id = envelope.Message.DataIntegrationId;
                var state = new DataIntegrationState();
                var integration = new DataIntegration(id, state);
                var command = envelope.Message;
                await _repository.Save(id,
                    new RepositoryData<IDataIntegrationState>(
                        envelope,
                        state,
                        await integration.Submit(
                            name: envelope.Message.Name,
                            description: envelope.Message.Description,
                            documentName: envelope.Message.DocumentName,
                            documentType: envelope.Message.DocumentType,
                            document: envelope.Message.Document

                    )), cancellationToken);
            }
            catch (DuplicateRepositoryStateException)
            {
                _logger.LogWarning($"Duplicate integration submission : Id='{envelope.Message.DataIntegrationId}', Name='{envelope.Message.Name}', MessageId='{envelope.MessageId}'.");
            }
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<SubmitDataIntegration>(envelope), cancellationToken);
    }
}