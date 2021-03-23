using System.Threading.Tasks;

using Bistrotic.Domain.Communication;

namespace Bistrotic.DataIntegrations.Infrastructure
{
    public interface IDataIntegrationMailbox
    {
        Task<Email?> Read();
    }
}