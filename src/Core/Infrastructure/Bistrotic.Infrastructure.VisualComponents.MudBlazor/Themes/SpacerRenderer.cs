namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class SpacerRenderer : ComponentBaseRenderer<Spacer, MudAppBarSpacer>
    {
        public SpacerRenderer(Spacer component, RenderTreeBuilder builder) : base(component, builder)
        {
        }
    }
}