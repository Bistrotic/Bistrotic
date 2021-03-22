namespace Bistrotic.Infrastructure.VisualComponents.Controls
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Components.Rendering;

    public class Logo : BlazorComponent
    {
        public override string DefaultTagName => "img";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var attributes = (AdditionalAttributes == null) ?
                new Dictionary<string, object>() :
                new Dictionary<string, object>(AdditionalAttributes);
            attributes.Add("src", "logo.svg");
            attributes.Add("alt", "logo");
            attributes.Add("width", "32");
            attributes.Add("class", "logo");
            builder.OpenElement(0, TagName);
            builder.AddMultipleAttributes(1, attributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }
    }
}