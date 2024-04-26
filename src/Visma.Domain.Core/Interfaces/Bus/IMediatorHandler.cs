using Visma.Domain.Core.Commands;
using Visma.Domain.Core.Events;

namespace Visma.Domain.Core.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommandAsync<T>(T command) where T : Command;

        Task RaiseEventAsync<T>(T command) where T : Event;
    }
}
