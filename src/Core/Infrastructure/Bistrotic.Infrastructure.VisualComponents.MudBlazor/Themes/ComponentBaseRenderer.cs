namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    public class ComponentBaseRenderer<TComponent, TMud>
        where TComponent : BlazorComponent
        where TMud : ComponentBase
    {
        protected readonly RenderTreeBuilder _builder;
        protected readonly TComponent _component;

        public ComponentBaseRenderer(TComponent component, RenderTreeBuilder builder)
        {
            _component = component;
            _builder = builder;
        }

        public virtual int Render(int sequence)
        {
            _builder.OpenComponent(sequence++, typeof(TMud));
            sequence = RenderAttributes(sequence);
            _builder.CloseComponent();
            return sequence;
        }

        public virtual int RenderAttributes(int sequence)
        {
            _builder.AddMultipleAttributes(sequence++, _component.AdditionalAttributes);
            return sequence;
        }
    }
}