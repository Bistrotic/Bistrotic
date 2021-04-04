#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable CS8603 // Possible null reference return.

namespace Bistrotic.Infrastructure.EfCore.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Repositories;

    using Microsoft.EntityFrameworkCore;

    public abstract class StateStoreDbContext<TIState, TDbState>
        : DbContext, IRepository<TIState>
        where TDbState : class, TIState, IRepositoryStateMetadata, IRepositoryDbSet, new()
    {
        protected StateStoreDbContext(DbContextOptions options)
               : base(options)
        {
        }

        public DbSet<TDbState> States { get; set; }

        public async Task<TIState> CreateNew(string id, CancellationToken cancellationToken = default)
        {
            if (await Exists(id, cancellationToken).ConfigureAwait(false))
            {
                throw new DuplicateRepositoryStateException(this, id);
            }
            var state = new TDbState();
            States.Add(state);
            return state;
        }

        public async Task<object> CreateNew(Type dataType, string id, CancellationToken cancellationToken = default)
            => await CreateNew(id, cancellationToken).ConfigureAwait(false);

        public async Task<bool> Exists(string id, CancellationToken cancellationToken = default)
            => await States.FindAsync(GetKey(id), cancellationToken).ConfigureAwait(false) != null;

        public async Task<IRepositoryStateMetadata> GetMetadata(string id, CancellationToken cancellationToken = default)
            => await States.FindAsync(GetKey(id), cancellationToken).ConfigureAwait(false)
                    ?? throw new DuplicateRepositoryStateException(this, id);

        public async Task<TIState> GetState(string id, CancellationToken cancellationToken = default)
            => await States.FindAsync(GetKey(id), cancellationToken).ConfigureAwait(false)
                    ?? throw new DuplicateRepositoryStateException(this, id);

        public async Task<object> GetState(Type dataType, string id, CancellationToken cancellationToken = default)
            => await GetState(id, cancellationToken).ConfigureAwait(false);

        public Task<IRepositoryStream> GetStream(string id, CancellationToken cancellationToken = default)
            => Task.FromException<IRepositoryStream>(new NotSupportedException($"The repository {GetType().Name} does not support event streams. Trying to retreive stream '{id}'."));

        public Task Save(string id, IRepositoryData<TIState> stateData, CancellationToken cancellationToken = default)
        {
            if (!(stateData.State is TDbState))
            {
                return Task.FromException(
                    new RepositoryStateNullException(
                        this,
                        id, $"The state object given for saving Id='{id}' is null or not of type '{typeof(TDbState).Name}'. Data Type:'{stateData?.GetType()?.Name ?? "null"}'; Repository:'{GetType().Name}'."));
            }
            return SaveChangesAsync(cancellationToken);
        }

        public Task Save(string id, IRepositoryData stateData, CancellationToken cancellationToken = default)
            => Save(id, new RepositoryData<TIState>(stateData), cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventStreamItem>(b =>
            {
                b.HasKey(p => new { p.IdHash, p.Version, p.Id });
                b.Property(p => p.SystemUtcDateTime).HasDefaultValueSql("getdate()");
            });
        }

        private static object[] GetKey(string id)
            => new object[] { Hash(id), id };

        private static int Hash(string id) => id.GetHashCode(StringComparison.InvariantCulture);
    }
}