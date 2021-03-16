namespace Bistrotic.Infrastructure.BlazorComponents.Themes
{
    using System.Collections.Generic;

    using Bistrotic.Infrastructure.BlazorComponents.Exceptions;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class Theme : ComponentBase
    {
        private IThemeRenderer? _themeRenderer;

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public ThemeName Name { get; set; }

        private IThemeRenderer ThemeRenderer
        {
            get => _themeRenderer
              ?? throw new MissingMandatoryParamaterException<Theme>(nameof(Name));
            set => _themeRenderer = value;
        }

        public string RenderTagName(BlazorComponent component)
            => ThemeRenderer.RenderTagName(component);

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
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
            builder.OpenComponent<CascadingValue<Theme>>(i++);
            builder.AddAttribute(i++, nameof(CascadingValue<Theme>.Name), nameof(Theme));
            builder.AddAttribute(i++, nameof(CascadingValue<Theme>.Value), this);
            builder.AddAttribute(i++, nameof(CascadingValue<Theme>.ChildContent), ChildContent);
            builder.CloseComponent();
            builder.CloseElement();
            i++;
            builder.OpenElement(i++, "script");
            builder.AddAttribute(i++, "type", "module");
            builder.AddAttribute(i++, "src", ThemeRenderer.ThemeScript);
            builder.CloseElement();
        }

        protected override void OnParametersSet()
        {
            _themeRenderer = Name switch
            {
                ThemeName.Fluent => new FluentThemeRenderer(),
                ThemeName.Fast => new FluentThemeRenderer(),
                _ => throw new MissingMandatoryParamaterException<Theme>(nameof(Name))
            };
            base.OnParametersSet();
        }
    }
}