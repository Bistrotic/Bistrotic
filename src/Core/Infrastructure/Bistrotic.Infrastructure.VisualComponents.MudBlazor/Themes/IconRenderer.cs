namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class IconRenderer : ComponentRenderer<Icon, MudIcon>
    {
        public IconRenderer(Icon component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}