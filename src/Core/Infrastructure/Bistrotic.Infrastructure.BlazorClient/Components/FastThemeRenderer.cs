using System.Collections.Generic;

namespace Bistrotic.Infrastructure.BlazorClient.Components
{
    public class FastThemeRenderer : IThemeRendererer
    {
        public IEnumerable<KeyValuePair<string, object?>> ThemeAttributes
                 => new KeyValuePair<string, object?>[]
                     {
                    new KeyValuePair<string, object?>( "use-defaults", null )
                     };

        public string ThemeScript
            => "https://unpkg.com/@microsoft/fast-components";

        public string ThemeTagName => "fast-design-system-provider";

        public string RenderComponentTagName(BlazorComponent component)
        {
            return "fast-" + component.Name;
        }
    }
}