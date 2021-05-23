namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class AnchorRenderer : ComponentRenderer<Controls.Anchor, MudButton>
    {
        public AnchorRenderer(Controls.Anchor component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}