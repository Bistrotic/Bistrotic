using System.Threading.Tasks;

namespace Bistrotic.ApplicationLayer.Services
{
    public interface IApplicationNameService
    {
        Task<string> GetName();
    }
}