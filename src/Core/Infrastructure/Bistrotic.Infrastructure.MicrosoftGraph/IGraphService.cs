using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Graph;

namespace Bistrotic.Infrastructure.MicrosoftGraph
{
    public interface IGraphService
    {
        Task<IEnumerable<string>> GetUserIds();

        Task<IEnumerable<Message>> GetUserMails(string userPrincipalName);

        Task SetEmailAsRead(string recipient, string emailId);
    }
}