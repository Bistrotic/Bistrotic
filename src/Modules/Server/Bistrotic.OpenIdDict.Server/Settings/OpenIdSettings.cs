namespace Bistrotic.OpenIdDict.Settings
{
    using System.Collections.Generic;

    public class OpenIdSettings
    {
        public IEnumerable<string> AuthoriredUrls { get; } = new List<string>();
    }
}