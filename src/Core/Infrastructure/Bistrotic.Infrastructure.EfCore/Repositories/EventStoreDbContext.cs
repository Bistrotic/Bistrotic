#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8603 // Possible null reference return.

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Repositories;
    using Bistrotic.Infrastructure.EfCore.Helpers;

    using Microsoft.EntityFrameworkCore;

    public sealed class EventStoreDbContext<TIState, TState>
        : DbContext, IRepository<TIState>
        where TState : class, TIState, IRepositoryMetadata, IRepositoryDbSet, new()
    {
        public EventStoreDbContext(DbContextOptions<EventStoreDbContext<TIState, TState>> options)
               : base(options)
        {
        }

        public DbSet<EventStreamItem> EventStream { get; set; }

        public async Task<TIState> CreateNew(string id, CancellationToken cancellationToken = default)
        {
            if (await Exists(id, cancellationToken).ConfigureAwait(false))
            {
                throw new DuplicateRepositoryStateException(this, id);
            }
            return new TState();
        }

        public async Task<object> CreateNew(Type dataType, string id, CancellationToken cancellationToken = default)
            => await CreateNew(id, cancellationToken).ConfigureAwait(false);

        public async Task<bool> Exists(string id, CancellationToken cancellationToken = default)
            => await EventStream.FindAsync(GetKey(id), cancellationToken).ConfigureAwait(false) != null;

        public async Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default)
        {
            var first =
                await EventStream
                .Where(p =>
                    p.IdHash == id.HashKey()
                    && p.Id == id
                    && p.Version == 1)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false)
                    ?? throw new RepositoryStreamNotFoundException(this, id, "Can't find version 1 record.");
            var latest = await EventStream
                .Where(p =>
                    p.IdHash == id.HashKey()
                    && p.Id == id
                    && p.Version != 1)
                .OrderByDescending(p => p.Version)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
            return new RepositoryStateMetadata
            {
                CreatedByUser = first.UserName,
                CreatedUtcDateTime = first.SystemUtcDateTime,
                LastModifiedByUser = latest?.UserName,
                LastModifiedUtcDateTime = latest?.SystemUtcDateTime
            };
        }

        public Task<TIState> GetState(string id, CancellationToken cancellationToken = default)
            => Task.FromException<TIState>(
                new NotSupportedException($"The repository '{GetType().Name}' is an event stream. It does not support states."));

        public async Task<object> GetState(Type dataType, string id, CancellationToken cancellationToken = default)
            => await GetState(id, cancellationToken).ConfigureAwait(false);

        public Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default)
            => throw new NotSupportedException($"The repository '{GetType().Name}' does not support stream storage.");

        public Task Save(string id, IRepositoryData<TIState> stateData, CancellationToken cancellationToken = default)
            => Save(id, (IRepositoryData)stateData, cancellationToken);

        public Task Save(string id, IRepositoryData stateData, CancellationToken cancellationToken = default)
        {
            if (!(stateData.State is TState))
            {
                throw new RepositoryStateNullException(this, id, $"The state is null or not of type '{typeof(TState).Name}.");
            }
            return SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TState>(b =>
            {
                b.HasKey(p => new { p.IdHash, p.Version, p.Id });
                b.Property(p => p.SystemUtcDateTime).HasDefaultValueSql("getdate()");
            });
        }

        private static object[] GetKey(string id)
            => new object[] { id.HashKey(), id };
    }
}