using System.Collections.Generic;

namespace Bistrotic.Application.Repositories
{
    public interface IEventDrivenState
    {
        void Apply(IEnumerable<object> events);
    }
}