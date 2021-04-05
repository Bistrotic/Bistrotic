namespace Bistrotic.Emails.Application.Mappers
{
    using System;
    using System.Linq;

    using Bistrotic.Emails.Application.Commands;
    using Bistrotic.Infrastructure.MicrosoftGraph;

    using Microsoft.Graph;

    public static class GraphMessageMapper
    {
        public static ReceiveEmail MapToReceiveEmail(this Message message, string recipient)
        {
            var attachments = GraphService.GetFileAttachments(message.Attachments);
            return new()
            {
                EmailId = message.InternetMessageId,
                Subject = message.Subject ?? string.Empty,
                Body = message.Body.Content ?? string.Empty,
                Sender = message.Sender.EmailAddress.Address ?? string.Empty,
                Recipient = recipient,
                ToRecipients = message.ToRecipients?.Select(p => p.EmailAddress.Address)?.ToArray() ?? Array.Empty<string>(),
                CopyToRecipients = message.CcRecipients?.Select(p => p.EmailAddress.Address)?.ToArray() ?? Array.Empty<string>(),
                Attachments = attachments.Select(p => new Bistrotic.Emails.Contracts.ValueTypes.Attachment
                {
                    Name = p.Name,
                    Content = Convert.ToBase64String(p.ContentBytes)
                }),
            };
        }
    }
}