namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    public class AlertRenderer : ComponentRenderer<Alert, MudAlert>
    {
        public AlertRenderer(Alert component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}