namespace Bistrotic.Infrastructure.VisualComponents
{
    using System.Collections.Generic;
    using System.Linq;

    using Bistrotic.Infrastructure.VisualComponents.Renderers;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class BlazorComponent : ComponentBase
    {
        #region Dependencies

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Inject]
        protected IComponentRendererProvider RendererProvider { get; init; }

        public virtual int RenderContent(int sequence, RenderTreeBuilder builder)
        {
            return sequence;
        }

#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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

        public virtual RenderFragment? ChildFragment => null;

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

        [CascadingParameter] public string ThemeName { get; set; } = default!;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var renderer = RendererProvider.GetRenderer(ThemeName, GetType());
            if (renderer == null)
            {
                base.BuildRenderTree(builder);
            }
            else
            {
                renderer.BuildRenderTree(this, builder);
            }
        }
    }
}