using System;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Commands;
using Bistrotic.Application.Messages;
using Bistrotic.Domain.ValueTypes;
using Bistrotic.Emails.Exceptions;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bistrotic.Emails
{
    public abstract class EmailsJob<TCommand> : BackgroundService
        where TCommand : class
    {
        private readonly ICommandBus _commandBus;
        private readonly ILogger _logger;
        private readonly IOptions<EmailsSettings> _settings;

        protected EmailsJob(
            ICommandBus commandBus,
            IOptions<EmailsSettings> settings,
            ILogger logger)
        {
            _commandBus = commandBus;
            _settings = settings;
            _logger = logger;
        }

        public abstract TCommand Command { get; }

        public string Recipient => Settings.ReceiveEmailsRecipient
               ?? throw new MailboxRecipientNotDefinedException($"Job {TaskName}.");

        public abstract int Recurrence { get; }
        public string TaskName => typeof(TCommand).Name;
        protected EmailsSettings Settings => _settings.Value;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var startInSeconds = Math.Max(60, Settings.ReceiveMailsStartSeconds);

            _logger.LogDebug($"Job {TaskName} : Starting. Wait before first execution : {startInSeconds} seconds; Recurrence : {Recurrence} seconds.");

            stoppingToken.Register(() =>
                _logger.LogDebug($"Job {TaskName} : Stopping."));

            await Task.Delay(startInSeconds * 1000, stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                MessageId messageId = new();
                _logger.LogInformation($"Job {TaskName} is executing. MessageId : {messageId.Value}.");
                var task1 = _commandBus.Send<TCommand>(new Envelope<TCommand>(
                        Command,
                        messageId,
                        "scheduler",
                        DateTimeOffset.Now
                ), stoppingToken);
                var task2 = Task.Delay(Recurrence * 1000, stoppingToken);
                await Task.WhenAll(task1, task2);
            }

            _logger.LogDebug($"Job {TaskName} is stopping.");
        }
    }
}