namespace Bistrotic.MudBlazorTheme.Renderers.MudBlazor
{
    using Bistrotic.ApplicationLayer.Controls;
    using Bistrotic.Infrastructure.VisualComponents;
    using Bistrotic.Infrastructure.VisualComponents.MudBlazor.Renderers;

    using global::MudBlazor;

    using Microsoft.AspNetCore.Components.Rendering;

    internal sealed record ApplicationNameRenderer : MudComponentBaseRenderer<ApplicationName, MudText>
    {
        public override int RenderContent(int sequence, BlazorComponent blazorComponent, RenderTreeBuilder builder)
        {
            builder.AddContent(sequence++, ((ApplicationName)blazorComponent).Name);
            return sequence;
        }
    }
}