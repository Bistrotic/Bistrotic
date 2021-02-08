using System;
using System.Linq;
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
            Type handlerType = MakeQueryHandlerInterface(typeof(TQuery), typeof(TResult));
            object? service = _serviceProvider.GetService(handlerType);
            if (service == null)
            {
                return Task.FromException<TResult>(new QueryHandlerNotFoundException(query.GetType()));
            }
            IQueryHandler<TQuery, TResult>? handler = service as IQueryHandler<TQuery, TResult>;
            return handler?.Handle(query)
                ?? Task.FromException<TResult>(new InvalidQueryHandlerTypeException(service.GetType(), typeof(IQueryHandler<TQuery, TResult>)));
        }

        public async Task<object?> Dispatch(IQuery query)
        {
            Type? genericQueryType = Array.Find(query.GetType().GetInterfaces(), p => p.IsGenericType && p.GetGenericTypeDefinition() == typeof(IQuery<>));
            if (genericQueryType == null)
            {
                throw new InvalidQueryTypeException(query.GetType(), $"Does not implement type {typeof(IQuery<>).Name}");
            }
            Type? resultType = genericQueryType.GenericTypeArguments.FirstOrDefault();
            if (resultType == null)
            {
                throw new InvalidQueryTypeException(query.GetType(), $"Can't retreive generic type {typeof(IQuery<>).Name} argument.");
            }

            Type handlerType = MakeQueryHandlerInterface(query.GetType(), resultType);
            object? service = _serviceProvider.GetService(handlerType);
            if (service == null)
            {
                throw new QueryHandlerNotFoundException(query.GetType());
            }
            var handleMethod = service.GetType().GetMethod("Handle", new[] { query.GetType() });
            if (handleMethod == null)
            {
                throw new InvalidQueryHandlerTypeException($"Handle method not found on handler '{service.GetType().FullName}'.");
            }
            if (handleMethod.Invoke(service, new[] { query }) is Task<object> resultTask)
            {
                var result = await resultTask.ConfigureAwait(false);
                if (resultType.IsInstanceOfType(result))
                {
                    return result;
                }
                throw new InvalidQueryHandlerTypeException($"Handle method returns a value with an invalid type on handler '{service.GetType().FullName}': Expected:{resultType.Name}; Result:{result.GetType().Name}.");
            }
            else
            {
                throw new InvalidQueryHandlerTypeException($"Handle method returns null on handler '{service.GetType().FullName}'.");
            }
        }

        private static Type MakeQueryHandlerInterface(Type queryType, Type resultType)
        {
            Type handlerType = typeof(IQueryHandler<,>).MakeGenericType(new Type[] { queryType, resultType });
            if (handlerType == null)
            {
                throw new InvalidQueryHandlerTypeException($"Cannot create the type IQueryHandler<{queryType.Name},{resultType.Name}>.");
            }
            return handlerType;
        }
    }
}