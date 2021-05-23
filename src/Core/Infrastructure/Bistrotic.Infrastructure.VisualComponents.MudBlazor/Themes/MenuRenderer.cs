namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class MenuRenderer : ComponentRenderer<Menu, MudMenu>
    {
        public MenuRenderer(Menu component, RenderTreeBuilder builder) : base(component, builder)
        { }
    }
}