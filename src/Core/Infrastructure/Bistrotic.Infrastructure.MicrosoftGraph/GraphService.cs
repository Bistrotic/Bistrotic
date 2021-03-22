namespace Bistrotic.Infrastructure.MicrosoftGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Bistrotic.Domain.Communication;

    using Microsoft.Graph;

    public class GraphService
    {
        private GraphServiceClient? _graphClient;

        public GraphService(GraphAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        protected GraphAuthenticationService AuthenticationService { get; }
        protected GraphServiceClient GraphClient => _graphClient ??= InitializeGraphClient();

        public async Task<IEnumerable<string>> GetUserIds()
        {
            var users = await GraphClient
                .Users
                .Request()
                .GetAsync()
                .ConfigureAwait(false);
            List<string> ids = new(users.Select(p => p.UserPrincipalName));
            while (users.NextPageRequest != null)
            {
                users = await users
                    .NextPageRequest
                    .GetAsync()
                    .ConfigureAwait(false);
                ids.AddRange(users.Select(p => p.UserPrincipalName).ToArray());
            }
            return ids;
        }

        public async Task<IEnumerable<Email>> GetUserMails(string userPrincipalName)
        {
            var messages = await GraphClient
                .Users[userPrincipalName]
                .Messages
                .Request()
                .Expand(p => p.Attachments)
                .GetAsync()
                .ConfigureAwait(false);

            List<Email> ids = new(messages.Select(p => Map(p)));
            while (messages.NextPageRequest != null)
            {
                messages = await messages
                    .NextPageRequest
                    .GetAsync()
                    .ConfigureAwait(false);
                ids.AddRange(messages.Select(p => Map(p)));
            }
            return ids;
        }

        private GraphServiceClient InitializeGraphClient()
              => new(AuthenticationService.AuthenticationProvider);

        private Email Map(Message message)
        {
            return new Email
            {
                Subject = message.Subject ?? string.Empty,
                Body = message.Body.Content ?? string.Empty,
                Sender = message.Sender.EmailAddress.Address ?? string.Empty,
                ToRecipients = message.ToRecipients?.Select(p => p.EmailAddress.Address)?.ToArray() ?? Array.Empty<string>(),
                CopyToRecipients = message.CcRecipients?.Select(p => p.EmailAddress.Address)?.ToArray() ?? Array.Empty<string>(),
                Attachments = Map(message.Attachments)
            };
        }

        private IReadOnlyList<EmailAttachment> Map(IMessageAttachmentsCollectionPage? attachments)
        {
            if (attachments == null || attachments.Count == 0)
            {
                return Array.Empty<EmailAttachment>();
            }
            List<EmailAttachment> files = new List<EmailAttachment>(attachments.Select(p => Map(p)));
            while (attachments.NextPageRequest != null)
            {
                attachments = attachments.NextPageRequest.GetAsync().GetAwaiter().GetResult();
                files.AddRange(attachments.Select(p => Map(p)));
            }
            return files;
        }

        private EmailAttachment Map(Attachment attachment)
        {
            return new EmailAttachment { Name = attachment.Name };
        }
    }
}