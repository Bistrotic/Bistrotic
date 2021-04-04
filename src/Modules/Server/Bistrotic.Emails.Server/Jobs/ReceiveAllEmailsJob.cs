using System;

using Bistrotic.Application.Commands;
using Bistrotic.Emails.Application.Commands;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bistrotic.Emails
{
    public sealed class ReceiveAllEmailsJob : EmailsJob<ReceiveAllEmails>
    {
        public ReceiveAllEmailsJob(
            ICommandBus commandBus,
            IOptions<EmailsSettings> settings,
            ILogger<ReceiveAllEmailsJob> logger)
            : base(commandBus, settings, logger)
        {
        }

        public override ReceiveAllEmails Command => new ReceiveAllEmails
        {
            Recipient = Recipient
        };

        public override int Recurrence => Math.Max(3600, Settings.ReceiveAllMailsRecurrenceSeconds);
    }
}