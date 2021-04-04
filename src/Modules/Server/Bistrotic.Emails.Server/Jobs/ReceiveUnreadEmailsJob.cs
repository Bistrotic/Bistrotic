using System;

using Bistrotic.Application.Commands;
using Bistrotic.Emails.Application.Commands;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bistrotic.Emails
{
    public sealed class ReceiveUnreadEmailsJob : EmailsJob<ReceiveUnreadEmails>
    {
        public ReceiveUnreadEmailsJob(
            ICommandBus commandBus,
            IOptions<EmailsSettings> settings,
            ILogger<ReceiveAllEmailsJob> logger)
            : base(commandBus, settings, logger)
        {
        }

        public override ReceiveUnreadEmails Command => new ReceiveUnreadEmails
        {
            Recipient = Recipient
        };

        public override int Recurrence => Math.Max(15, Settings.ReceiveUnreadMailsRecurrenceSeconds);
    }
}