namespace Bistrotic.Infrastructure.Ioc.Commands
{
    using System;

    using Bistrotic.Application.Commands;

    using Microsoft.Extensions.DependencyInjection;

    public static class IocCommandBusHelper
    {
        public static void AddCommandHandler<TCommand>(this IServiceCollection services, Func<IServiceProvider, ICommandHandler<TCommand>> handler)
                    where TCommand : class
        {
            services.AddTransient(handler);
        }

        public static void AddIocCommandDispatcher(this IServiceCollection services)
        {
            services.AddTransient<ICommandBus>(services => new IocCommandBus(services));
        }
    }
}