namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Infrastructure.VisualComponents.Controls;
    using Bistrotic.Infrastructure.VisualComponents.Controls.Icons;

    public class LineAwesomeIconRenderer : IIconRenderer
    {
        public IEnumerable<string> Scripts { get; }
            = Array.Empty<string>();

        public IEnumerable<string> Stylesheets
            => new[] { "https://maxst.icons8.com/vue-static/landings/line-awesome/line-awesome/1.3.0/css/line-awesome.min.css" };

        public string RenderClass(Icon icon)
            =>
            "las la-" + icon switch
            {
                HideMenuIcon => "chevron-circle-left",
                ShowMenuIcon => "chevron-circle-right",
                _ => icon.GetType().Name.DashCase()
            };

        public string RenderTag(Icon icon)
        {
            return "i";
        }
    }
}