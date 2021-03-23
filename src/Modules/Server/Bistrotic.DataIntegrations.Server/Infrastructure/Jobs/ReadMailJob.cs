namespace Bistrotic.DataIntegrations.Infrastructure.Jobs
{
    using System.Threading.Tasks;

    using Bistrotic.DataIntegrations.Infrastructure;
    using Bistrotic.Domain.Communication;

    using Quartz;

    public class ReadMailJob : IJob
    {
        private readonly IDataIntegrationMailbox _mailbox;

        public ReadMailJob(IDataIntegrationMailbox mailbox)
        {
            _mailbox = mailbox;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Email? email;
            while ((email = await _mailbox.Read()) != null)
            {
            }
        }
    }
}