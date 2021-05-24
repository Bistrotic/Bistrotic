namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using Microsoft.AspNetCore.Components;

    public class BlazorComponentWithContent : BlazorComponent
    {
        [Parameter] public RenderFragment? ChildContent { get; set; }

        public override RenderFragment? ChildFragment => ChildContent;
    }
}