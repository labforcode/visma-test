using MediatR;
using Visma.Domain.Commands.Employee.Actions;
using Visma.Domain.Core.Interfaces.UoW;
using Visma.Domain.Core.Notifications;

namespace Visma.Domain.Commands.Employee.Handlers
{
    public class UpdatingEmployeeSalaryCommandHandler : CommandHandler,
                                                        IRequestHandler<UpdatingEmployeeSalaryCommand, bool>
    {
        public UpdatingEmployeeSalaryCommandHandler(IUnitOfWork uow,
                                                    NotificationContext notificationContext) : base(uow, notificationContext)
        {
        }

        public async Task<bool> Handle(UpdatingEmployeeSalaryCommand request, CancellationToken cancellationToken)
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
