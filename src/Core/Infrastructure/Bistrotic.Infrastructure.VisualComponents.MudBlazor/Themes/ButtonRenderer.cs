namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ButtonRenderer : ComponentRenderer<Controls.Button, MudButton>
    {
        public ButtonRenderer(Controls.Button component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}