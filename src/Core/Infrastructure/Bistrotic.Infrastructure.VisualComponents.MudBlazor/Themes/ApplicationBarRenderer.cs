namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationBarRenderer : ComponentRenderer<ApplicationBar, MudAppBar>
    {
        public ApplicationBarRenderer(ApplicationBar component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}