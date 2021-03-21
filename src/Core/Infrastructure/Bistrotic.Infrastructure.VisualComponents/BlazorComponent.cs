namespace Bistrotic.Infrastructure.VisualComponents
{
    using System.Collections.Generic;

    using Bistrotic.Infrastructure.VisualComponents.Themes;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class BlazorComponent : ComponentBase
    {
        private string? _defaultTagName;
        private string? _tagName;

        #region Dependencies

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Inject]
        protected IComponentRenderer ComponentRenderer { get; init; }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #endregion Dependencies

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public virtual IReadOnlyCollection<string> Classes => new[] { GetType().Name.DashCase() + "-component" };

        public virtual string DefaultTagName
                    => _defaultTagName ??= GetType().Name.DashCase();

        public virtual string TagName => _tagName ??= DefaultTagName;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var attributes = (AdditionalAttributes == null) ?
                new Dictionary<string, object>() :
                new Dictionary<string, object>(AdditionalAttributes);
            string classes = string.Join(' ', Classes);
            if (attributes.TryGetValue("class", out object? value) && value is string classAttribute)
            {
                classes += ' ' + classAttribute;
            }
            attributes["class"] = classes;
            builder.OpenElement(0, TagName);
            builder.AddMultipleAttributes(1, attributes);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }

        protected override void OnParametersSet()
        {
            _tagName = ComponentRenderer.RenderTagName(this);
            base.OnParametersSet();
        }
    }
}