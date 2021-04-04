namespace Bistrotic.Emails
{
    public class EmailsSettings
    {
        public string? ConnectionString { get; init; }
        public int ReceiveAllMailsRecurrenceSeconds { get; init; }
        public string? ReceiveEmailsRecipient { get; init; }
        public int ReceiveMailsStartSeconds { get; init; }
        public int ReceiveUnreadMailsRecurrenceSeconds { get; init; }
    }
}