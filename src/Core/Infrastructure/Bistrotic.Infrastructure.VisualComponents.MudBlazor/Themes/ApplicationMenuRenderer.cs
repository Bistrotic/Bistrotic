namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationMenuRenderer : ComponentRenderer<ApplicationMenu, MudAppBar>
    {
        public ApplicationMenuRenderer(ApplicationMenu component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}