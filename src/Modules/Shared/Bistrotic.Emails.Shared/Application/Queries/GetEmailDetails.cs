namespace Bistrotic.Emails.Application.Queries
{
    using Bistrotic.Emails.Application.ModelViews;
    using Bistrotic.Emails.Domain.ValueTypes;

    internal sealed class GetEmailDetails
    {
        public GetEmailDetails(EmailId emailId)
        {
            EmailId = emailId;
        }

        public string EmailId { get; }
    }
}