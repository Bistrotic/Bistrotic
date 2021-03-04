namespace Bistrotic.OpenIdDict.Settings
{
    using System.Collections.Generic;

    public class OpenIdSettings
    {
        public IEnumerable<string> AuthorizedUrls { get; init; } = new List<string>();
        public IEnumerable<string> CertificatePaths { get; init; } = new List<string>();
        public string? EncryptionCertificateFile { get; init; }
        public string? EncryptionCertificateThumbprint { get; init; }
        public string? SigningCertificateFile { get; init; }
        public string? SigningCertificateFilePassword { get; init; }
        public string? SigningCertificateThumbprint { get; init; }
        public string? SigningCertificateThumbprintPassword { get; init; }
    }
}