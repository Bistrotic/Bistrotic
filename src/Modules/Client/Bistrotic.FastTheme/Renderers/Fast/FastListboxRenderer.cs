namespace Bistrotic.FastTheme.Renderers.Fast
{
    using Bistrotic.FastTheme.Renderers;

    public sealed record FastListboxRenderer : ListboxRenderer
    {
        public FastListboxRenderer() : base(nameof(Fast))
        {
        }
    }
}