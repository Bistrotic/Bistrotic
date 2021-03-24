namespace Bistrotic.Application.Repositories
{
    using System.Collections.Generic;

    public interface IRepositoryData<out TState>
    {
        IEnumerable<object> Events { get; }
        IRepositoryMetadata Metadata { get; }
        TState State { get; }
    }
}