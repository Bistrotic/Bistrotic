namespace Bistrotic.DataIntegrations.Infrastructure
{
    using System.Threading.Tasks;

    using Bistrotic.Domain.Communication;

    public interface IDataIntegrationMailbox
    {
        Task<Email?> Read();
    }
}