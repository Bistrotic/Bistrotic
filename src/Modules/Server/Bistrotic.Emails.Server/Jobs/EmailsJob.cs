using System;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Commands;
using Bistrotic.Application.Messages;
using Bistrotic.Domain.ValueTypes;
using Bistrotic.Emails.Application.Settings;
using Bistrotic.Emails.Exceptions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bistrotic.Emails
{
    public abstract class EmailsJob<TCommand> : BackgroundService
        where TCommand : class
    {
        private readonly ILogger _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptions<EmailsSettings> _settings;

        protected EmailsJob(
            IServiceProvider serviceProvider,
            IOptions<EmailsSettings> settings,
            ILogger logger)
        {
            _serviceProvider = serviceProvider;
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
            var startInSeconds = Math.Max(10, Settings.ReceiveMailsStartSeconds);

            _logger.LogDebug($"Job {TaskName} : Starting. Wait before first execution : {startInSeconds} seconds; Recurrence : {Recurrence} seconds.");

            stoppingToken.Register(() =>
                _logger.LogDebug($"Job {TaskName} : Stopping."));

            await Task.Delay(startInSeconds * 1000, stoppingToken);
            while (!stoppingToken.IsCancellationRequested)
            {
                MessageId messageId = new();
                _logger.LogInformation($"Job {TaskName} is executing. MessageId : {messageId.Value}.");
                var timerTask = Task.Delay(Recurrence * 1000, stoppingToken);
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    ICommandBus commandBus = scope.ServiceProvider.GetRequiredService<ICommandBus>();
                    IOptions<EmailsSettings> settings = scope.ServiceProvider.GetRequiredService<IOptions<EmailsSettings>>();
                    await commandBus.Send(new Envelope<TCommand>(
                            Command,
                            messageId,
                            "scheduler",
                            DateTimeOffset.Now
                    ), stoppingToken);
                }
                catch (Exception e)
                {
                    _logger.LogError($"Job '{typeof(TCommand).Name}' Error (Id={messageId.Value}): {e.Message}.");
                }
                await timerTask;
            }

            _logger.LogDebug($"Job {TaskName} is stopping.");
        }
    }
}