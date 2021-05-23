using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public class FastComponentRenderer : FastAndFluentComponentRenderer
    {
        public FastComponentRenderer() : base("fast")
        {
        }

        public override IEnumerable<string> Scripts
            => new[] { "https://unpkg.com/@microsoft/fast-components" };
    }
}