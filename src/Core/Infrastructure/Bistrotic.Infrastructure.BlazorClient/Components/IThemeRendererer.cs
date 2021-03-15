using System.Collections.Generic;

namespace Bistrotic.Infrastructure.BlazorClient.Components
{
    public interface IThemeRendererer
    {
        IEnumerable<KeyValuePair<string, object?>> ThemeAttributes { get; }

        string ThemeScript { get; }
        string ThemeTagName { get; }

        string RenderComponentTagName(BlazorComponent component);
    }
}