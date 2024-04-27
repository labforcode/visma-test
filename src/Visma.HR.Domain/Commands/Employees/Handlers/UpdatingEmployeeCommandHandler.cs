using MediatR;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Domain.Commands.Employees.Handlers
{
    public class UpdatingEmployeeCommandHandler : CommandHandler,
                                                  IRequestHandler<UpdatingEmployeeCommand, bool>
    {
        public UpdatingEmployeeCommandHandler(IUnitOfWork uow,
                                              NotificationContext notificationContext) : base(uow, notificationContext)
        {
        }

        public async Task<bool> Handle(UpdatingEmployeeCommand request, CancellationToken cancellationToken)
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
