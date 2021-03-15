namespace Bistrotic.Infrastructure.BlazorClient.Components
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class Theme : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [CascadingParameter]
        protected IThemeRendererer? ThemeRenderer { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (ThemeRenderer == null)
                throw new Exception("Renderer not defined");
            builder.OpenElement(0, ThemeRenderer.ThemeTagName);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            int i = 2;
            foreach (var pair in ThemeRenderer.ThemeAttributes)
            {
                if (pair.Value == null)
                    builder.AddAttribute(i++, pair.Key);
                else
                    builder.AddAttribute(i++, pair.Key, pair.Value);
            }
            builder.AddContent(i++, ChildContent);
            builder.CloseElement();
            i++;
            builder.OpenElement(i++, "script");
            builder.AddAttribute(i++, "type", "module");
            builder.AddAttribute(i++, "src", ThemeRenderer.ThemeScript);
            builder.CloseElement();
        }
    }
}