using MediatR;
using Visma.Domain.Commands.Employee.Actions;
using Visma.Domain.Core.Interfaces.UoW;
using Visma.Domain.Core.Notifications;

namespace Visma.Domain.Commands.Employee.Handlers
{
    public class DeletingEmployeeCommandHandler : CommandHandler,
                                                  IRequestHandler<DeletingEmployeeCommand, bool>
    {
        public DeletingEmployeeCommandHandler(IUnitOfWork uow,
                                              NotificationContext notificationContext) : base(uow, notificationContext)
        {
        }

        public async Task<bool> Handle(DeletingEmployeeCommand command, CancellationToken cancellationToken)
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
