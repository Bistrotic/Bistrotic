﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Emails.Application.Commands;
using Bistrotic.Emails.Application.Exceptions;
using Bistrotic.Emails.Application.Mappers;
using Bistrotic.Emails.Application.Settings;
using Bistrotic.Infrastructure.MicrosoftGraph;

using Microsoft.Extensions.Options;

namespace Bistrotic.Emails.Application.Services
{
    public class GraphMailboxService : IMailboxService
    {
        private readonly IOptions<EmailsSettings> _settings;

        private GraphService? _graphService;

        public GraphMailboxService(IOptions<EmailsSettings> settings)
        {
            _settings = settings;
        }

        private GraphService GraphService => _graphService ??= InitializeGraphService();

        public Task<IEnumerable<string>> GetUserIds(CancellationToken cancellationToken = default)
            => GraphService.GetUserIds(cancellationToken);

        public async Task<IEnumerable<ReceiveEmail>> GetUserMails(string userPrincipalName, CancellationToken cancellationToken = default)
            => (await GraphService.GetUserMails(userPrincipalName, cancellationToken))
                .Select(p => p.MapToReceiveEmail(userPrincipalName))
                .ToList();

        public Task SetEmailAsRead(string userPrincipalName, string emailId, CancellationToken cancellationToken = default)
            => GraphService.SetEmailAsRead(userPrincipalName, emailId, cancellationToken);

        private GraphService InitializeGraphService()
           => new(new GraphAuthenticationService(
                _settings.Value.MicrosoftGraph?.TenantId
                    ?? throw new GraphMailboxServiceSettingsException(nameof(EmailsSettings) + ":" + nameof(EmailsSettings.MicrosoftGraph) + nameof(EmailsSettings.MicrosoftGraph.TenantId), string.Empty),
                _settings.Value.MicrosoftGraph?.ClientId
                   ?? throw new GraphMailboxServiceSettingsException(nameof(EmailsSettings) + ":" + nameof(EmailsSettings.MicrosoftGraph) + nameof(EmailsSettings.MicrosoftGraph.ClientId), string.Empty),
                 _settings.Value.MicrosoftGraph?.ClientSecret
                    ?? throw new GraphMailboxServiceSettingsException(nameof(EmailsSettings) + ":" + nameof(EmailsSettings.MicrosoftGraph) + nameof(EmailsSettings.MicrosoftGraph.ClientSecret), string.Empty),
                _settings.Value.MicrosoftGraph?.Authority
                ));
    }
}