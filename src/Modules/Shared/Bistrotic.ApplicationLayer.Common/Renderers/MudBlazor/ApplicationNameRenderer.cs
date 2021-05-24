namespace Bistrotic.ApplicationLayer.Renderers.MudBlazor
{
    using Bistrotic.ApplicationLayer.Controls;
    using Bistrotic.Infrastructure.VisualComponents.Controls;

    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    internal class ApplicationNameRenderer : MudBlazorComponentRenderer<ApplicationName>
    {
        public ApplicationNameRenderer(ApplicationName component, RenderTreeBuilder builder) : base(component, builder)
        {
        }

        public override int RenderContent(int sequence)
        {
            _builder.AddContent(sequence++, _component.Name);
            return sequence;
        }
    }
}