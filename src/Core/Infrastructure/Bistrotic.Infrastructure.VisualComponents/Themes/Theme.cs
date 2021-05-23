namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    using System.Collections.Generic;

    public class Theme : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        #region Dependencies

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Inject]
        private IComponentRenderer ComponentRenderer { get; init; }

        [Inject]
        private IIconRenderer IconRenderer { get; init; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #endregion Dependencies

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int i = 0;
            foreach (string stylesheet in ComponentRenderer.Stylesheets)
            {
                builder.OpenElement(i++, "link");
                builder.AddAttribute(i++, "rel", "stylesheet");
                builder.AddAttribute(i++, "href", stylesheet);
                builder.CloseElement();
            }
            foreach (string stylesheet in IconRenderer.Stylesheets)
            {
                builder.OpenElement(i++, "link");
                builder.AddAttribute(i++, "rel", "stylesheet");
                builder.AddAttribute(i++, "href", stylesheet);
                builder.CloseElement();
            }
            i = ComponentRenderer.OpenTheme(i, builder);
            builder.AddMultipleAttributes(i++, AdditionalAttributes);
            foreach (var pair in ComponentRenderer.ThemeAttributes)
            {
                if (pair.Value == null)
                    builder.AddAttribute(i++, pair.Key);
                else
                    builder.AddAttribute(i++, pair.Key, pair.Value);
            }
            builder.OpenComponent<CascadingValue<Theme>>(i++);
            builder.AddAttribute(i++, nameof(CascadingValue<Theme>.Name), nameof(Theme));
            builder.AddAttribute(i++, nameof(CascadingValue<Theme>.Value), this);
            builder.AddAttribute(i++, nameof(CascadingValue<Theme>.ChildContent), ChildContent);
            builder.CloseComponent();
            i = ComponentRenderer.CloseTheme(i, builder);
            foreach (string script in ComponentRenderer.Scripts)
            {
                builder.OpenElement(i++, "script");
                builder.AddAttribute(i++, "type", "module");
                builder.AddAttribute(i++, "src", script);
                builder.CloseElement();
            }
            foreach (string script in IconRenderer.Scripts)
            {
                builder.OpenElement(i++, "script");
                builder.AddAttribute(i++, "type", "module");
                builder.AddAttribute(i++, "src", script);
                builder.CloseElement();
            }
        }
    }
}