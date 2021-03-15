using System.Collections.Generic;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Bistrotic.Infrastructure.BlazorClient.Components
{
    public class BlazorComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public virtual string Name => this.GetType().Name.ToLowerInvariant();

        [CascadingParameter]
        protected IThemeRendererer? ThemeRenderer { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, ThemeRenderer?.RenderComponentTagName(this) ?? Name);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}