using System.Collections.Generic;

namespace Bistrotic.Infrastructure.BlazorComponents.Themes
{
    public interface IThemeRenderer
    {
        IEnumerable<KeyValuePair<string, object?>> ThemeAttributes { get; }

        string ThemeScript { get; }
        string ThemeTagName { get; }

        string RenderTagName(BlazorComponent component);
    }
}