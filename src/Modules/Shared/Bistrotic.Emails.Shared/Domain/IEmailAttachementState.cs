namespace Bistrotic.Emails.Domain
{
    internal interface IEmailAttachement
    {
        public string? Content { get; set; }
        public string Name { get; set; }
    }
}