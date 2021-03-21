using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public class FluentComponentRenderer : FastAndFluentThemeRenderer
    {
        public FluentComponentRenderer() : base("fluent")
        {
        }

        public override IEnumerable<string> Scripts
          => new string[] { "https://unpkg.com/@fluentui/web-components" };
    }
}