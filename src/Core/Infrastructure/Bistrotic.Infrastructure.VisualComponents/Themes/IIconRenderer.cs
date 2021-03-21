using System.Collections.Generic;

using Bistrotic.Infrastructure.VisualComponents.Controls;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public interface IIconRenderer
    {
        IEnumerable<string> Scripts { get; }
        IEnumerable<string> Stylesheets { get; }

        string RenderClass(Icon icon);

        string RenderTag(Icon icon);
    }
}