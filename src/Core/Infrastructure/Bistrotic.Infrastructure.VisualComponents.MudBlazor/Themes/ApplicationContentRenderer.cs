namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationContentRenderer : ComponentRenderer<ApplicationContent, MudMainContent>
    {
        public ApplicationContentRenderer(ApplicationContent component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}