namespace Bistrotic.OpenIdDict.Settings
{
    using System.Collections.Generic;

    public class OpenIdSettings
    {
        public IEnumerable<string> AuthoriredUrls { get; } = new List<string>();
        public string? EncryptionCertificateThumbprint { get; }
        public string? SigningCertificateThumbprint { get; }
    }
}