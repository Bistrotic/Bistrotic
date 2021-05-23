namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationNameRenderer : ComponentRenderer<ApplicationName, MudText>
    {
        public ApplicationNameRenderer(ApplicationName component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}