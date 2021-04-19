
namespace Bistrotic.UblDocuments.Application.Events
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.UblDocuments.Types;
    using Bistrotic.UblDocuments.Types.Aggregates;
    using Bistrotic.UblInvoices.Application;

    [EventHandler(Event = typeof(DataIntegrationSubmitted))]
    public class DataIntegrationSubmittedHandler : IEventHandler<DataIntegrationSubmitted>
    {
        private readonly IUblIntegrationRepository _repository;

        public DataIntegrationSubmittedHandler(IUblIntegrationRepository repository)
        {
            _repository = repository;
        }
        public Task Handle(Envelope<DataIntegrationSubmitted> envelope, CancellationToken cancellationToken = default)
        {
            if (envelope.Message.DocumentType != "Xml")
            {
                var data = Convert.FromBase64String(envelope.Message.Data);
                using MemoryStream stream = new(data);
                XDocument xml = XDocument.Load(stream);
                if (xml.Root?.Name?.LocalName == nameof(AttachedDocument) && xml.Root?.Name?.Namespace == UblNamespaces.AttachedDocument2)
                {
                    XmlSerializer serializer = new(typeof(AttachedDocument));
                    var doc = (AttachedDocument?)serializer.Deserialize(xml.CreateReader());
                    if (doc == null)
                    {
                        throw new UblXmlDeserilizationException($"Error while deserializing UBL xml document in {nameof(DataIntegrationSubmitted)} message '{envelope.MessageId}' :\n" + xml.ToString());
                    }
                    var content = doc.Attachment?.ExternalReference?.Description;
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        throw new UblXmlDeserilizationException($"AttachedDocument.Attachment.ExternalReference.Description is empty. It should contain the UBL Invoice XML. Message Id='{envelope.MessageId}' :\n" + xml.ToString());
                    }
                    xml = XDocument.Parse(content);
                }
                if (xml.Root?.Name?.LocalName == nameof(Invoice) && xml.Root?.Name?.Namespace == UblNamespaces.Invoice2)
                {
                    _repository.Add(new UblIntegration
                    {
                        Name = envelope.Message.Name,
                        Description = envelope.Message.Description,
                        IntegrationId = envelope.Message.DataIntegrationId,
                        MessageId = envelope.MessageId,
                        Data = xml.ToString(),
                    });
                }
            }
            return Task.CompletedTask;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<DataIntegrationSubmitted>(envelope), cancellationToken);
    }
}
