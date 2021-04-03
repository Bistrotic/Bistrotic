namespace Bistrotic.Infrastructure.MicrosoftGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Graph;

    public class GraphService : IGraphService
    {
        private GraphServiceClient? _graphClient;

        public GraphService(GraphAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;
        }

        protected GraphAuthenticationService AuthenticationService { get; }
        protected GraphServiceClient GraphClient => _graphClient ??= InitializeGraphClient();

        public static IReadOnlyList<Attachment> GetAttachments(IMessageAttachmentsCollectionPage? attachments)
        {
            if (attachments == null || attachments.Count == 0)
            {
                return Array.Empty<Attachment>();
            }
            List<Attachment> files = new(attachments.ToArray());
            while (attachments.NextPageRequest != null)
            {
                attachments = attachments
                    .NextPageRequest
                    .GetAsync()
                    .GetAwaiter()

                    .GetResult();
                files.AddRange(attachments.ToList());
            }
            return files;
        }

        public static IReadOnlyList<FileAttachment> GetFileAttachments(IMessageAttachmentsCollectionPage? attachments)
        {
            if (attachments == null || attachments.Count == 0)
            {
                return Array.Empty<FileAttachment>();
            }
            List<FileAttachment> files = new(attachments.OfType<FileAttachment>().ToArray());
            while (attachments.NextPageRequest != null)
            {
                attachments = attachments
                    .NextPageRequest
                    .GetAsync()
                    .GetAwaiter()
                    .GetResult();
                files.AddRange(attachments.OfType<FileAttachment>().ToList());
            }
            return files;
        }

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

        public async Task<IEnumerable<Message>> GetUserMails(string userPrincipalName)
        {
            var messages = await GraphClient
                .Users[userPrincipalName]
                .Messages
                .Request()
                .Expand(p => p.Attachments)
                .GetAsync()
                .ConfigureAwait(false);

            List<Message> ids = new(messages.ToList());
            while (messages.NextPageRequest != null)
            {
                messages = await messages
                    .NextPageRequest
                    .GetAsync()
                    .ConfigureAwait(false);
                ids.AddRange(messages.ToList());
            }
            return ids;
        }

        public async Task SetEmailAsRead(string recipient, string emailId)
        {
            var msg = await GraphClient
                   .Users[recipient]
                   .Messages[emailId]
                   .Request()
                   .Select(nameof(Message.IsRead))
                   .GetAsync()
                   .ConfigureAwait(false);

            if (msg.IsRead != true)
            {
                await GraphClient
                    .Users[recipient]
                    .Messages[emailId]
                    .Request()
                    .UpdateAsync(new Message()
                    {
                        IsRead = true
                    })
                    .ConfigureAwait(false);
            }
        }

        private GraphServiceClient InitializeGraphClient()
                    => new(AuthenticationService.AuthenticationProvider);
    }
}