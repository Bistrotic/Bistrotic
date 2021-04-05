using System;

using Bistrotic.Emails.Application.Commands;
using Bistrotic.Emails.Application.Settings;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bistrotic.Emails
{
    public sealed class ReceiveAllEmailsJob : EmailsJob<ReceiveAllEmails>
    {
        public ReceiveAllEmailsJob(
            IServiceProvider serviceProvider,
            IOptions<EmailsSettings> settings,
            ILogger<ReceiveAllEmailsJob> logger)
            : base(serviceProvider, settings, logger)
        {
        }

        public override ReceiveAllEmails Command => new ReceiveAllEmails
        {
            Recipient = Recipient
        };

        public override int Recurrence => Math.Max(3600, Settings.ReceiveAllMailsRecurrenceSeconds);
    }
}