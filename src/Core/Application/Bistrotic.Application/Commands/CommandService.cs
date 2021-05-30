using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Bistrotic.Application.Messages;
using Bistrotic.Application.Services;
using Bistrotic.Domain.ValueTypes;

namespace Bistrotic.Application.Commands
{
    public class CommandService : ICommandService
    {
        private readonly ICommandBus _commandBus;
        private readonly IUserIdentity _userIdentity;

        public CommandService(ICommandBus commandBus, IUserIdentity userIdentity)
        {
            _commandBus = commandBus;
            _userIdentity = userIdentity;
        }

        public Task Tell<TCommand>(TCommand command, string? messageId = null, CancellationToken cancellationToken = default)
            where TCommand : class
            => _commandBus.Send(new Envelope<TCommand>(command, messageId ?? new MessageId(), _userIdentity.UserName, DateTimeOffset.Now), cancellationToken);
    }
}