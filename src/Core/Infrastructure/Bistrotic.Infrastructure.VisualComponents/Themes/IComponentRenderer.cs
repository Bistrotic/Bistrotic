using Microsoft.AspNetCore.Components.Rendering;

using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public interface IComponentRenderer
    {
        IEnumerable<string> Scripts { get; }
        IEnumerable<string> Stylesheets { get; }
        IEnumerable<KeyValuePair<string, object?>> ThemeAttributes { get; }

        string ThemeTagName { get; }

        int BuildRenderTree(int sequence, BlazorComponent component, RenderTreeBuilder builder);

        int CloseTheme(int sequence, RenderTreeBuilder builder);

        int OpenTheme(int sequence, RenderTreeBuilder builder);
    }
}