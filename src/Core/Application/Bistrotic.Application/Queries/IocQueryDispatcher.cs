using System;
using System.Threading.Tasks;

using Bistrotic.Application.Exceptions;

namespace Bistrotic.Application.Queries
{
    public class IocQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public IocQueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            Type handlerGenericType = typeof(IQueryHandler<,>);
            Type handlerType = handlerGenericType.MakeGenericType(new Type[] { query.GetType(), typeof(TResult) });
            object? service = _serviceProvider.GetService(handlerType);
            if (service == null)
            {
                return Task.FromException<TResult>(new QueryHandlerNotFoundException(query.GetType()));
            }
            IQueryHandler<TQuery, TResult>? handler = service as IQueryHandler<TQuery, TResult>;
            return handler?.Handle(query)
                ?? Task.FromException<TResult>(new InvalidQueryHandlerTypeException(service.GetType(), typeof(IQueryHandler<TQuery, TResult>)));
        }
    }
}