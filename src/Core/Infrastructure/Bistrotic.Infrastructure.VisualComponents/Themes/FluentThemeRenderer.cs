using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public class FluentThemeRenderer : IThemeRenderer
    {
        public IEnumerable<KeyValuePair<string, object?>> ThemeAttributes
            => new KeyValuePair<string, object?>[]
                {
                    new KeyValuePair<string, object?>( "use-defaults", null )
                };

        public string ThemeScript
            => "https://unpkg.com/@fluentui/web-components";

        public string ThemeTagName => "fluent-design-system-provider";

        public string RenderTagName(BlazorComponent component)
        {
            return "fluent-" + component.DefaultTagName;
        }
    }
}