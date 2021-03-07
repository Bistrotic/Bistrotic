namespace Bistrotic.MicrosoftIdentity
{
    using System.Collections.Generic;
    public class AzureAdSettings
    {
        public string? Instance { get; init; }
        public string? ClientId { get; init; }
        public string? TenantId { get; init; }
        public string? ClientSecret { get; init; }
        public IEnumerable<string>? ClientCertificates { get; init; }
    };
    public class MicrosoftGraphSettings
    {
        public string? MicrosoftGraph { get; init; }
        public string? BaseUrl { get; init; }
        public string? Scopes { get; init; }
    };
    public class MicrosoftIdentitySettings
    {
        public AzureAdSettings AzureAd { get; init; } = new AzureAdSettings();
        public MicrosoftGraphSettings MicrosoftGraph { get; init; } = new MicrosoftGraphSettings();
    }
}
