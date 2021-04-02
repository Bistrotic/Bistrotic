namespace Bistrotic.Emails.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Emails.Domain.Events;
    using Bistrotic.Emails.Domain.Exceptions;
    using Bistrotic.Emails.Domain.ValueTypes;

    internal class Email
    {
        private readonly string _id;
        private EmailState _state;

        public Email(string id, EmailState state)
        {
            _state = state ?? throw new EmailStateNotInitializedException("Email Id: " + _id);
            _id = id;
        }

        public Task<IEnumerable<object>> Receive(
            string recipient,
            string subject,
            string body,
            string sender,
            IEnumerable<string> toRecipients,
            IEnumerable<string> copyToRecipients,
            IEnumerable<Attachment> attachments
            )
        {
            List<object> events = new()
            {
                new EmailReceived(
                    recipient: recipient,
                    emailId: _id,
                    subject: subject,
                    body: body,
                    sender: sender,
                    toRecipients: toRecipients.Select(p => new EmailAddress(p)),
                    copyToRecipients: copyToRecipients.Select(p => new EmailAddress(p)),
                    attachements: attachments
            )
            };
            return Apply(events);
        }

        private Task<IEnumerable<object>> Apply(IEnumerable<object> events)
        {
            foreach (var e in events)
            {
                switch (e)
                {
                    case EmailReceived @event:
                        _state.Apply(@event);
                        break;

                    default:
                        throw new NotSupportedException($"The event type '{e.GetType().Name}' is not supported by '{_state.GetType().Name}'.");
                }
            }
            return Task.FromResult(events);
        }
    }
}