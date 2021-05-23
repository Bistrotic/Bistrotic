namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationSearchRenderer : ComponentRenderer<ApplicationSearch, MudText>
    {
        public ApplicationSearchRenderer(ApplicationSearch component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}