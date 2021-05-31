namespace Bistrotic.Infrastructure.VisualComponents
{
    using System.Collections.Generic;
    using System.Linq;

    using Bistrotic.Application.Commands;
    using Bistrotic.Application.Queries;
    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public abstract class BlazorComponent : ComponentBase
    {
        #region Dependencies

        [Inject]
        protected ICommandService CommandService { get; init; } = default!;

        [Inject]
        protected IQueryService QueryService { get; init; } = default!;

        [Inject]
        protected IComponentRendererProvider RendererProvider { get; init; } = default!;

        #endregion Dependencies

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>
        /// Additional user class names, separated by space added to the component's own classes
        /// </summary>
        [Parameter] public string? AdditionalClasses { get; set; }

        /// <summary>
        /// Additional user styles, applied on top of the component's own styles
        /// </summary>
        [Parameter] public string? AdditionalStyles { get; set; }

        [Parameter] public RenderFragment? ChildContent { get; set; }

        public virtual IReadOnlyCollection<string> Classes
        {
            get
            {
                List<string> list = new();
                list.Add(GetType().Name.DashCase() + "-component");
                if (!string.IsNullOrWhiteSpace(AdditionalClasses))
                {
                    var classes = AdditionalClasses.Split(" ").Where(p => !string.IsNullOrWhiteSpace(p));
                    if (classes.Any())
                    {
                        list.AddRange(classes);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// User data object Tag.
        /// </summary>
        [Parameter] public object? Tag { get; set; }

        [CascadingParameter(Name = nameof(ThemeName))]
        public string ThemeName
        {
            get => _themeName;
            set { _themeName = value; StateHasChanged(); }
        }

        private string _themeName { get; set; } = "Fast";

        public virtual int Render(int sequence, RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenElement(sequence++, "div");
            builder.AddContent(sequence++, (string.IsNullOrWhiteSpace(ThemeName)) ? $"No theme name defined for component '{GetType().Name}'." : $"No renderer found for '{GetType().Name}' in theme '{ThemeName}'");
            if (ChildContent != null)
            {
                builder.AddContent(sequence++, ChildContent);
            }
            builder.CloseElement();
            return sequence;
        }

        public virtual int RenderContent(int sequence, RenderTreeBuilder builder)
        {
            if (ChildContent != null)
            {
                builder.AddContent(sequence++, ChildContent);
            }
            return sequence;
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var renderer = RendererProvider.GetRenderer(ThemeName, GetType());
            if (renderer == null)
            {
                Render(0, builder);
            }
            else
            {
                renderer.BuildRenderTree(this, builder);
            }
        }
    }
}