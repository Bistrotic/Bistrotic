namespace Bistrotic.DataIntegrations.Application.Commands
{
    using System.Threading.Tasks;

    using Bistrotic.Application;
    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Domain;

    internal class SubmitDataIntegrationHandler : CommandHandler<SubmitDataIntegration>
    {
        private readonly IRepository<DataIntegrationState> _repository;

        public SubmitDataIntegrationHandler(IRepository<DataIntegrationState> repository)
        {
            _repository = repository;
        }
        public override Task Handle(Envelope<SubmitDataIntegration> envelope)
        {
            var command = envelope.Message;
            var events = DataIntegration.SubmitDataIntegration(
                command.DataIntegrationId,
                command.Name,
                command.Description,
                command.DocumentName,
                command.Document,
                out DataIntegrationState integration
                );
            return _repository.Save(
                command.DataIntegrationId,
                new RepositoryData<DataIntegrationState>(envelope, integration, events)
                );
        }
    }
}