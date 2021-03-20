namespace Bistrotic.Infrastructure.Client
{
    using System.Collections.Generic;
    public interface IMenuService
    {
        IReadOnlyList<MenuItemDefinition> MenuItems { get; }
    }
}
