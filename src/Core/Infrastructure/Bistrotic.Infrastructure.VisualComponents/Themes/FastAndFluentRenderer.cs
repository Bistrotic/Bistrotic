using System;
using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public abstract class FastAndFluentThemeRenderer : IComponentRenderer
    {
        private readonly string _prefix;

        private readonly HashSet<string> _supportedTags = new(
        new string[] {
            "accordion",
            "anchor",
            "anchored-region",
            "badge",
            "breadcrumb",
            "button",
            "card",
            "checkbox",
            "data-grid",
            "dialog",
            "disclosure",
            "divider",
            "flipper",
            "listbox",
            "menu",
            "menu-item",
            "number-field",
            "progress-ring",
            "progress",
            "radio",
            "radio-group",
            "select",
            "skeleton",
            "slider",
            "switch",
            "tabs",
            "text-area",
            "text-field",
            "tooltip",
            "tree-view",
            "option"
        });

        protected FastAndFluentThemeRenderer(string prefix)
        {
            _prefix = prefix;
        }

        public abstract IEnumerable<string> Scripts { get; }
        public IEnumerable<string> Stylesheets => Array.Empty<string>();

        public IEnumerable<KeyValuePair<string, object?>> ThemeAttributes
                         => new KeyValuePair<string, object?>[]
                     {
                    new KeyValuePair<string, object?>( "use-defaults", null )
                     };

        public string ThemeTagName => _prefix + "-design-system-provider";

        public string RenderTagName(BlazorComponent component)
            => _supportedTags.Contains(component.TagName.ToLowerInvariant()) ?
                 _prefix + "-" + component.DefaultTagName :
                component.DefaultTagName;
    }
}