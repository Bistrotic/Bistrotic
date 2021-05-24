namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using Bistrotic.Infrastructure.VisualComponents;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class FluentThemeRenderer : IComponentRenderer<Theme>
    {
        public void BuildRenderTree(BlazorComponent blazorComponent, RenderTreeBuilder builder)
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