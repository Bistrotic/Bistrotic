using System;
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
        public Task<TResult> Ask<TQuery, TResult>(string messageId, TQuery query) where TQuery : class
            => _queryDispatcher
                    .Dispatch<TQuery, TResult>(new Envelope<TQuery>(query, messageId, _user?.Identity?.Name, DateTimeOffset.Now));
    }
}