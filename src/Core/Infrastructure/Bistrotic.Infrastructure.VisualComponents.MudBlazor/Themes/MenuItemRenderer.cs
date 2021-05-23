namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class MenuItemRenderer : ComponentRenderer<MenuItem, MudMenuItem>
    {
        public MenuItemRenderer(MenuItem component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}