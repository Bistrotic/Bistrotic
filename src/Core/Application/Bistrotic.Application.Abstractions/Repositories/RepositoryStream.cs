#pragma warning disable CA1711 // Identifiers should not have incorrect suffix

namespace Bistrotic.Application.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class RepositoryStream : IRepositoryStream
    {
        private readonly Dictionary<long, (IRepositoryMetadata metadata, IEnumerable<object> events)> _stream = new();

        public long Position => _stream.Last().Key;

        public long Add(IRepositoryMetadata metadata, IEnumerable<object> events)
        {
            var index = Position + 1;
            _stream.Add(index, (metadata, events));
            return index;
        }

        public (IRepositoryMetadata metadata, IEnumerable<object> events) Read(long position)
            => _stream[position];
    }
}