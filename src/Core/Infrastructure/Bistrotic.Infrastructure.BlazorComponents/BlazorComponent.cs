namespace Bistrotic.Infrastructure.BlazorComponents
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Infrastructure.BlazorComponents.Themes;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class BlazorComponent : ComponentBase
    {
        private string? _defaultTagName;
        private string? _tagName;

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public virtual string DefaultTagName
            => _defaultTagName ??= GetType().Name.DashCase();

        public virtual string TagName => _tagName ??= DefaultTagName;

        [CascadingParameter(Name = nameof(Theme))]
        public Theme? Theme { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, TagName);
            builder.AddMultipleAttributes(1, AdditionalAttributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"Theme name : {Theme?.Name}.");
            _tagName = Theme?.RenderTagName(this);
            base.OnParametersSet();
        }
    }
}