using MediatR;
using Visma.HR.Domain.Core.Commands;
using Visma.HR.Domain.Core.Events;
using Visma.HR.Domain.Core.Interfaces.Bus;

namespace Visma.HR.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommandAsync<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEventAsync<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
