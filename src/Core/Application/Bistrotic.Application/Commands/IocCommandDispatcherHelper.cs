namespace Bistrotic.Application.Commands
{
    using System;

    using Microsoft.Extensions.DependencyInjection;

    public static class IocCommandDispatcherHelper
    {
        public static void AddCommandHandler<TCommand>(this IServiceCollection services, Func<IServiceProvider, ICommandHandler<TCommand>> handler)
                    where TCommand : class
        {
            services.AddTransient(handler);
        }

        public static void AddIocCommandDispatcher(this IServiceCollection services)
        {
            services.AddTransient<ICommandDispatcher>(services => new IocCommandDispatcher(services));
        }
    }
}