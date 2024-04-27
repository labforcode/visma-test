using MediatR;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Domain.Commands.Employees.Handlers
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
