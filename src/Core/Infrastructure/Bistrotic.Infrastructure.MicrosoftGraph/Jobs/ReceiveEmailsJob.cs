namespace Bistrotic.Infrastructure.MicrosoftGraph.Jobs
{
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using Quartz;

    [DisallowConcurrentExecution]
    public class ReceiveEmailsJob : IJob
    {
        private readonly ILogger<ReceiveEmailsJob> _logger;

        public ReceiveEmailsJob(IGraphService mailService, ILogger<ReceiveEmailsJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Hello world!");
            return Task.CompletedTask;
        }
    }
}