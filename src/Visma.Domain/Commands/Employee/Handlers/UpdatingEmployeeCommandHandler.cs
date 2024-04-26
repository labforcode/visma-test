using MediatR;
using Visma.Domain.Commands.Employee.Actions;
using Visma.Domain.Core.Interfaces.UoW;
using Visma.Domain.Core.Notifications;

namespace Visma.Domain.Commands.Employee.Handlers
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
