using System;
using System.Linq;

using Bistrotic.Emails.Application.Commands;
using Bistrotic.Infrastructure.MicrosoftGraph;

using Microsoft.Graph;

namespace Bistrotic.Emails.Application.Mappers
{
    internal static class GraphMessageMapper
    {
        public static ReceiveEmail MapToReceiveEmail(this Message message)
        {
            var attachments = GraphService.GetFileAttachments(message.Attachments);
            return new()
            {
                Subject = message.Subject ?? string.Empty,
                Body = message.Body.Content ?? string.Empty,
                Sender = message.Sender.EmailAddress.Address ?? string.Empty,
                ToRecipients = message.ToRecipients?.Select(p => p.EmailAddress.Address)?.ToArray() ?? Array.Empty<string>(),
                CopyToRecipients = message.CcRecipients?.Select(p => p.EmailAddress.Address)?.ToArray() ?? Array.Empty<string>(),
                AttachmentNames = attachments.Select(p => p.Name),
                AttachmentContents = attachments.Select(p => Convert.ToBase64String(p.ContentBytes))
            };
        }
    }
}