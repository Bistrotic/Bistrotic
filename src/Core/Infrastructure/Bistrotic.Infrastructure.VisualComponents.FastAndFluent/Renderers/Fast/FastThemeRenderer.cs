namespace Bistrotic.Infrastructure.VisualComponents.Renderers.Fast
{
    using Bistrotic.Infrastructure.VisualComponents;
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    public class FluentThemeRenderer : FastComponentRendererBase<Theme>
    {
        public FluentThemeRenderer() : base("fast-design-system-provider")
        {

        }
        protected override int RenderElement(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            sequence = base.RenderElement(sequence, blazorComponent, builder);
            builder.OpenElement(sequence++, "script");
            builder.AddAttribute(sequence++, "type", "module");
            builder.AddAttribute(sequence++, "src", "https://unpkg.com/@microsoft/fast-components");
            builder.CloseElement();
            return sequence;
        }
        protected override int RenderAttributes(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            builder.AddAttribute(sequence++, "use-defaults");
            return base.RenderAttributes(sequence, blazorComponent, builder);
        }
    }
}