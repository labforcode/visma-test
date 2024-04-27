using Visma.HR.Domain.Core.Commands;
using Visma.HR.Domain.Core.Events;

namespace Visma.HR.Domain.Core.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommandAsync<T>(T command) where T : Command;

        Task RaiseEventAsync<T>(T @event) where T : Event;
    }
}
