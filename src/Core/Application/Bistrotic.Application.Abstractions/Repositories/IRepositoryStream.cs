#pragma warning disable CA1711 // Identifiers should not have incorrect suffix

namespace Bistrotic.Application.Repositories
{
    using System.Collections.Generic;

    public interface IRepositoryStream
    {
        long Position { get; }

        long Add(IRepositoryMetadata metadata, IEnumerable<object> events);

        (IRepositoryMetadata metadata, IEnumerable<object> events) Read(long position);
    }
}