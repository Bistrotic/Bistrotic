using System.Collections.Generic;

namespace Bistrotic.Infrastructure.BlazorClient.Components
{
    public class FluentThemeRenderer : IThemeRendererer
    {
        public IEnumerable<KeyValuePair<string, object?>> ThemeAttributes
            => new KeyValuePair<string, object?>[]
                {
                    new KeyValuePair<string, object?>( "use-defaults", null )
                };

        public string ThemeScript
            => "https://unpkg.com/@microsoft/fluent-components";

        public string ThemeTagName => "fluent-design-system-provider";

        public string RenderComponentTagName(BlazorComponent component)
        {
            return "fluent-" + component.Name;
        }
    }
}