using MediatR;
using Visma.Domain.Commands.Employee.Actions;
using Visma.Domain.Core.Interfaces.UoW;
using Visma.Domain.Core.Notifications;

namespace Visma.Domain.Commands.Employee.Handlers
{
    public class AddingEmployeeCommandHandler : CommandHandler,
                                                IRequestHandler<AddingEmployeeCommand, bool>
    {
        public AddingEmployeeCommandHandler(IUnitOfWork uow,
                                            NotificationContext notificationContext) : base(uow, notificationContext)
        {
        }

        public async Task<bool> Handle(AddingEmployeeCommand command, CancellationToken cancellationToken)
        {
            try
            {


                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
