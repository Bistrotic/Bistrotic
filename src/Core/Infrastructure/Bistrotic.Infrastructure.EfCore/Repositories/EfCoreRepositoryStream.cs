#pragma warning disable CA1711 // Identifiers should not have incorrect suffix

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using System;
    using System.Collections.Generic;

    using Bistrotic.Application.Repositories;

    public sealed class EfCoreRepositoryStream : IRepositoryStream
    {
        private readonly List<(IRepositoryMetadata metadata, IEnumerable<object> events)> _stream = new();

        public int Position => _stream.Count;

        public int Add(IRepositoryMetadata metadata, IEnumerable<object> events)
        {
            _stream.Add((metadata, events));
            return Position;
        }

        public (IRepositoryMetadata metadata, IEnumerable<object> events) Read(int position)
            => (position >= 1) ? _stream[position - 1] :
                throw new ArgumentException($"The position must be higher or equal than one. Position={position}.", nameof(position));
    }
}