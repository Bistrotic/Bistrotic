namespace Bistrotic.Infrastructure.VisualComponents
{
    using Bistrotic.Infrastructure.VisualComponents.Themes;

    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    using System.Collections.Generic;
    using System.Linq;

    public class BlazorComponent : ComponentBase
    {
        #region Dependencies

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Inject]
        protected IComponentRenderer ComponentRenderer { get; init; }

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

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            ComponentRenderer.BuildRenderTree(0, this, builder);
        }
    }
}