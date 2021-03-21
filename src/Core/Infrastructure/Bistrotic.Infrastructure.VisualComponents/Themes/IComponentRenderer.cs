using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public interface IComponentRenderer
    {
        IEnumerable<string> Scripts { get; }
        IEnumerable<string> Stylesheets { get; }
        IEnumerable<KeyValuePair<string, object?>> ThemeAttributes { get; }

        string ThemeTagName { get; }

        string RenderTagName(BlazorComponent component);
    }
}