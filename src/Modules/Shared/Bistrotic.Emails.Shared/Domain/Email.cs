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
        private EmailState? _state;
        private readonly string _id;

        public Email(string id, EmailState? state)
        {
            _state = state;
            _id = id;
        }

        internal EmailState State => _state ?? throw new EmailStateNotInitializedException("Email Id: " + _id);

        public Task<IEnumerable<object>> ReceiveEmail(
            string recipient,
            string subject,
            string body,
            string sender,
            IEnumerable<string> toRecipients,
            IEnumerable<string> copyToRecipients,
            IEnumerable<Attachment> attachements
            )
        {
            if (_state == null)
            {
                throw new DuplicateEmailException($"Duplicate email : Id = '{_id}'");
            }
            _state = new EmailState();
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
                    attachements: attachements
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
                        State.Apply(@event);
                        break;

                    default:
                        throw new NotSupportedException($"The event type '{e.GetType().Name}' is not supported by '{State.GetType().Name}'.");
                }
            }
            return Task.FromResult(events);
        }
    }
}