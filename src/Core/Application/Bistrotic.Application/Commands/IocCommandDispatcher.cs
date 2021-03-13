namespace Bistrotic.Application.Commands
{
    using System;
    using System.Threading.Tasks;

    using Bistrotic.Application.Exceptions;
    using Bistrotic.Application.Messages;

    public class IocCommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public IocCommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public Task Dispatch<TCommand>(Envelope<TCommand> envelope)
            where TCommand : class
        {
            Type handlerType = MakeCommandHandlerInterface(typeof(TCommand));
            object? service = _serviceProvider.GetService(handlerType);
            if (service == null)
            {
                return Task.FromException(new CommandHandlerNotFoundException(envelope.Message.GetType()));
            }
            ICommandHandler<TCommand>? handler = service as ICommandHandler<TCommand>;
            return handler?.Handle(envelope)
                ?? Task.FromException(new InvalidCommandHandlerTypeException(service.GetType(), typeof(ICommandHandler<TCommand>)));
        }

        public async Task Dispatch(IEnvelope envelope)
        {
            Type? genericCommandType = Array.Find(envelope.Message.GetType().GetInterfaces(), p => p.IsGenericType && p.GetGenericTypeDefinition() == typeof(ICommand));
            if (genericCommandType == null)
            {
                throw new InvalidCommandTypeException(envelope.Message.GetType(), $"Does not implement type {typeof(ICommand).Name}");
            }

            Type handlerType = MakeCommandHandlerInterface(envelope.Message.GetType());
            object? service = _serviceProvider.GetService(handlerType);
            if (service == null)
            {
                throw new CommandHandlerNotFoundException(envelope.Message.GetType());
            }
            var handleMethod = service.GetType().GetMethod("Handle", new[] { envelope.GetType() });
            if (handleMethod == null)
            {
                throw new InvalidCommandHandlerTypeException($"Handle method not found on handler '{service.GetType().FullName}'.");
            }
            if (handleMethod.Invoke(service, new[] { envelope }) is Task resultTask)
            {
                await resultTask.ConfigureAwait(false);
            }
            else
            {
                throw new InvalidCommandHandlerTypeException($"Handle method returns null on handler '{service.GetType().FullName}'.");
            }
        }

        private static Type MakeCommandHandlerInterface(Type CommandType)
        {
            Type handlerType = typeof(ICommandHandler<>).MakeGenericType(new Type[] { CommandType });
            if (handlerType == null)
            {
                throw new InvalidCommandHandlerTypeException($"Cannot create the type ICommandHandler<{CommandType.Name}>.");
            }
            return handlerType;
        }
    }
}