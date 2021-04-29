
namespace Bistrotic.UblDocuments.Application.Events
{
    using Bistrotic.Application.Events;
    using Bistrotic.Application.Messages;
    using Bistrotic.Application.Repositories;
    using Bistrotic.DataIntegrations.Contracts.Events;
    using Bistrotic.UblDocuments.Domain;
    using Bistrotic.UblDocuments.Domain.States;
    using Bistrotic.UblDocuments.Types;
    using Bistrotic.UblDocuments.Types.Aggregates;

    using Microsoft.Extensions.Logging;

    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    [EventHandler(Event = typeof(DataIntegrationSubmitted))]
    public class DataIntegrationSubmittedHandler : IEventHandler<DataIntegrationSubmitted>
    {
        private readonly IRepository<IUblInvoiceState> _repository;
        private readonly IEventBus _eventBus;
        private readonly ILogger<DataIntegrationSubmittedHandler> _logger;

        public DataIntegrationSubmittedHandler(
            IRepository<IUblInvoiceState> repository,
            IEventBus eventBus,
            ILogger<DataIntegrationSubmittedHandler> logger)
        {
            _repository = repository;
            _eventBus = eventBus;
            _logger = logger;
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
                    XmlSerializer serializer = new(typeof(Invoice));
                    var reader = xml.CreateReader();
                    reader.MoveToContent();
                    var invoice = (Invoice?)serializer.Deserialize(reader);
                    if (invoice == null)
                    {
                        throw new UblXmlDeserilizationException($"Error while deserializing UBL Invoice in {nameof(DataIntegrationSubmitted)} message '{envelope.MessageId}' :\n" + xml.ToString());
                    }
                    if (string.IsNullOrWhiteSpace(invoice.UUID))
                    {
                        throw new UblXmlDeserilizationException($"Error while deserializing UBL Invoice in {nameof(DataIntegrationSubmitted)}. The UUID field is empty. Message '{envelope.MessageId}' :\n" + xml.ToString());
                    }
                    if (await _repository.Exists(invoice.UUID, cancellationToken))
                    {
                        _logger.LogWarning($"Duplicate UBL Invoice. UUID='{invoice.UUID}',  ID='{invoice.ID}'. Message '{envelope.MessageId}'");
                    }
                    UblInvoiceState state = new();
                    UblInvoice ublInvoice = new(invoice.UUID, state);
                    var events = await ublInvoice.Submit(invoice);
                    await _repository.Save(
                        invoice.UUID,
                        new RepositoryData<UblInvoiceState>(
                            envelope,
                            state,
                            await ublInvoice.Submit(invoice)),
                        cancellationToken);
                    return;
                }
                //if (xml.Root?.Name?.LocalName == nameof(External.MexicanDocuments.Voucher) && xml.Root?.Name?.Namespace == External.MexicanDocuments.MxNamespaces.Cfdi)
                //{
                //    XmlSerializer serializer = new(typeof(External.MexicanDocuments.Voucher));
                //    var reader = xml.CreateReader();
                //    reader.MoveToContent();
                //    var voucher = (External.MexicanDocuments.Voucher?)serializer.Deserialize(reader);
                //    if (voucher == null)
                //    {
                //        throw new UblXmlDeserilizationException($"Error while deserializing Mexican digital invoice voucher in {nameof(DataIntegrationSubmitted)} message '{envelope.MessageId}' :\n" + xml.ToString());
                //    }

                //    await IntegrationDone(integration, voucher.ToUblInvoice(), cancellationToken);
                //    return;

                //}
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


        public Task Handle(IEnvelope envelope, CancellationToken cancellationToken = default)
            => Handle(new Envelope<DataIntegrationSubmitted>(envelope), cancellationToken);
    }
}
