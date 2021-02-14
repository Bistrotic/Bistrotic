using System.Security.Principal;
using System.Threading.Tasks;

using Bistrotic.Application.Messages;

namespace Bistrotic.Application.Queries
{
    public class DispatchQueryService : IQueryService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly IPrincipal _user;

        public DispatchQueryService(IQueryDispatcher queryDispatcher, IPrincipal user)
        {
            _queryDispatcher = queryDispatcher;
            _user = user;
        }

        /// <exclude/>
        public Task<TResult> Ask<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
            => _queryDispatcher
                    .Dispatch<TQuery, TResult>(new Envelope<TQuery>(query, _user?.Identity?.Name));
    }
}