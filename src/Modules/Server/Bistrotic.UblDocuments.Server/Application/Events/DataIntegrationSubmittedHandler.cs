
namespace Bistrotic.UblDocuments.Application.Events
{
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.UblDocuments.External.MexicanDocuments.Helpers;
    using Bistrotic.UblDocuments.Types;
    using Bistrotic.UblDocuments.Types.Aggregates;

    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    [EventHandler(Event = typeof(DataIntegrationSubmitted))]
    public class DataIntegrationSubmittedHandler : IEventHandler<DataIntegrationSubmitted>
    {
        private readonly IRepository _repository;

        public DataIntegrationSubmittedHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(Envelope<DataIntegrationSubmitted> envelope, CancellationToken cancellationToken = default)
        {
            if (envelope.Message.DocumentType == "Xml")
            {
                if (string.IsNullOrWhiteSpace(envelope.Message.Document))
                {
                    throw new UblXmlDeserilizationException($"Message document is empty. It should contain an XML document. Message Id='{envelope.MessageId}'.");
                }
                var data = Convert.FromBase64String(envelope.Message.Document);
                using MemoryStream stream = new(data);
                XDocument xml = XDocument.Load(stream);
                if (xml.Root?.Name?.LocalName == nameof(AttachedDocument) && xml.Root?.Name?.Namespace == UblNamespaces.AttachedDocument2)
                {
                    xml = UblAttachedDocument(envelope, xml);
                }
                if (xml.Root?.Name?.LocalName == nameof(Invoice) && xml.Root?.Name?.Namespace == UblNamespaces.Invoice2)
                {
                    Integration integration = await LogIntegration(envelope, xml, cancellationToken);
                    XmlSerializer serializer = new(typeof(Invoice));
                    var reader = xml.CreateReader();
                    reader.MoveToContent();
                    var invoice = (Invoice?)serializer.Deserialize(reader);
                    if (invoice == null)
                    {
                        throw new UblXmlDeserilizationException($"Error while deserializing UBL Invoice in {nameof(DataIntegrationSubmitted)} message '{envelope.MessageId}' :\n" + xml.ToString());
                    }
                    await IntegrationDone(integration, invoice, cancellationToken);
                    return;
                }
                if (xml.Root?.Name?.LocalName == nameof(External.MexicanDocuments.Voucher) && xml.Root?.Name?.Namespace == External.MexicanDocuments.MxNamespaces.Cfdi)
                {
                    Integration integration = await LogIntegration(envelope, xml, cancellationToken);
                    XmlSerializer serializer = new(typeof(External.MexicanDocuments.Voucher));
                    var reader = xml.CreateReader();
                    reader.MoveToContent();
                    var voucher = (External.MexicanDocuments.Voucher?)serializer.Deserialize(reader);
                    if (voucher == null)
                    {
                        throw new UblXmlDeserilizationException($"Error while deserializing Mexican digital invoice voucher in {nameof(DataIntegrationSubmitted)} message '{envelope.MessageId}' :\n" + xml.ToString());
                    }

                    await IntegrationDone(integration, voucher.ToUblInvoice(), cancellationToken);
                    return;

                }
            }
        }

        private static XDocument UblAttachedDocument(Envelope<DataIntegrationSubmitted> envelope, XDocument xml)
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
            return XDocument.Parse(content);
        }

        private Task IntegrationDone(Integration integration, Invoice? invoice, CancellationToken cancellationToken)
        {
            _repository.Add(invoice);
            integration.IntegrationDate = DateTimeOffset.Now;
            return _repository.Save(cancellationToken);
        }

        private async Task<Integration> LogIntegration(Envelope<DataIntegrationSubmitted> envelope, XDocument xml, CancellationToken cancellationToken)
        {
            var integration = new Integration
            {
                Name = envelope.Message.Name,
                Description = envelope.Message.Description,
                IntegrationId = envelope.Message.DataIntegrationId,
                MessageId = envelope.MessageId,
                ReceivedDate = DateTimeOffset.Now,
                Data = xml.ToString(),
            };
            _repository.Add(integration);
            await _repository.Save(cancellationToken);
            return integration;
        }

        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<DataIntegrationSubmitted>(envelope), cancellationToken);
    }
}
