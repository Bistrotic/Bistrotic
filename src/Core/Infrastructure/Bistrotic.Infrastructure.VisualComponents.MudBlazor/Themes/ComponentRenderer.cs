namespace Bistrotic.Infrastructure.VisualComponents.Themes
{
    using Microsoft.AspNetCore.Components.Rendering;

    using MudBlazor;

    public class ComponentRenderer<TComponent, TMud> : ComponentBaseRenderer<TComponent, TMud>
        where TComponent : BlazorComponent
        where TMud : MudComponentBase
    {
        public ComponentRenderer(TComponent component, RenderTreeBuilder builder) : base(component, builder)
        {
        }

        public override int RenderAttributes(int sequence)
        {
            _builder.AddAttribute(sequence++, nameof(MudComponentBase.Class), string.Join(' ', _component.Classes));
            _builder.AddAttribute(sequence++, nameof(MudComponentBase.Style), _component.AdditionalStyles);
            _builder.AddAttribute(sequence++, nameof(MudComponentBase.Tag), _component.Tag);
            return base.RenderAttributes(sequence++);
        }
    }
}