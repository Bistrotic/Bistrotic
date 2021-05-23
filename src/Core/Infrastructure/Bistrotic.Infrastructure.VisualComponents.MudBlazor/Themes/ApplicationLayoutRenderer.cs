namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationLayoutRenderer : ComponentRenderer<ApplicationLayout, MudLayout>
    {
        public ApplicationLayoutRenderer(ApplicationLayout component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}