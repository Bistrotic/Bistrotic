using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Emails.Application.Commands;

namespace Bistrotic.Emails.Application.Services
{
    public interface IMailboxService
    {
        Task<IEnumerable<string>> GetUserIds(CancellationToken cancellationToken = default);

        Task<IEnumerable<ReceiveEmail>> GetUserMails(string userPrincipalName, CancellationToken cancellationToken = default);

        Task SetEmailAsRead(string userPrincipalName, string emailId, CancellationToken cancellationToken = default);
    }
}