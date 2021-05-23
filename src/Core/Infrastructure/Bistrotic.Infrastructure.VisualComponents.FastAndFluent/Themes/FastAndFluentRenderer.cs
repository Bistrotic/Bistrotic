using Microsoft.AspNetCore.Components.Rendering;

using System;
using System.Collections.Generic;

namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    public abstract class FastAndFluentComponentRenderer : IComponentRenderer
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

        protected FastAndFluentComponentRenderer(string prefix)
        {
            _prefix = prefix;
        }

        public bool IsContainerTheme { get; } = true;
        public abstract IEnumerable<string> Scripts { get; }
        public IEnumerable<string> Stylesheets => Array.Empty<string>();

        public IEnumerable<KeyValuePair<string, object?>> ThemeAttributes
                         => new KeyValuePair<string, object?>[]
                     {
                    new KeyValuePair<string, object?>( "use-defaults", null )
                     };

        public string ThemeTagName => _prefix + "-design-system-provider";

        public int BuildRenderTree(int sequence, BlazorComponent component, RenderTreeBuilder builder)
        {
            builder.OpenElement(sequence++, RenderTagName(component));
            builder.AddAttribute(sequence++, "class", string.Join(' ', component.Classes));
            builder.AddAttribute(sequence++, "style", component.AdditionalStyles);
            builder.AddMultipleAttributes(sequence++, component.AdditionalAttributes);
            if (component.ChildFragment != null)
            {
                builder.AddContent(sequence++, component.ChildFragment);
            }
            builder.CloseElement();
            return sequence;
        }

        public int CloseTheme(int sequence, RenderTreeBuilder builder)
        {
            builder.CloseElement();
            return sequence;
        }

        public int OpenTheme(int sequence, RenderTreeBuilder builder)
        {
            builder.OpenElement(sequence++, ThemeTagName);
            return sequence;
        }

        public string RenderTagName(BlazorComponent component)
            => _supportedTags.Contains(component.GetType().Name.DashCase()) ?
                 _prefix + "-" + component.GetType().Name.DashCase() :
                string.Empty;
    }
}