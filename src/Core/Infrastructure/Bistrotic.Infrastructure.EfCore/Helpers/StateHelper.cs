using System;

using Bistrotic.Infrastructure.EfCore.Repositories;

namespace Bistrotic.Infrastructure.EfCore.Helpers
{
    public static class StateHelper
    {
        public static int HashKey(this IRepositoryDbSet? state)
            => state?.Id?.HashKey() ?? 0;

        public static int HashKey(this string? key)
            => key?.GetHashCode(StringComparison.Ordinal) ?? 0;
    }
}