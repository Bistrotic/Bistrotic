using System;

using Bistrotic.Emails.Application.Commands;
using Bistrotic.Emails.Application.Settings;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bistrotic.Emails
{
    public sealed class ReceiveUnreadEmailsJob : EmailsJob<ReceiveUnreadEmails>
    {
        public ReceiveUnreadEmailsJob(
            IServiceProvider serviceProvider,
            IOptions<EmailsSettings> settings,
            ILogger<ReceiveAllEmailsJob> logger)
            : base(serviceProvider, settings, logger)
        {
        }

        public override ReceiveUnreadEmails Command => new ReceiveUnreadEmails
        {
            Recipient = Recipient
        };

        public override int Recurrence => Math.Max(15, Settings.ReceiveUnreadMailsRecurrenceSeconds);
    }
}