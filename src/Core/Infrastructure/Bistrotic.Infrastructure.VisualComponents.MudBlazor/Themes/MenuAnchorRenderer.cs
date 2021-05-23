namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class MenuAnchorRenderer : ComponentRenderer<MenuAnchor, MudIconButton>
    {
        public MenuAnchorRenderer(MenuAnchor component, RenderTreeBuilder builder) : base(component, builder)
        { }
    }
}