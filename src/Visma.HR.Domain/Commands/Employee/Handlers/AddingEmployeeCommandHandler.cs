using MediatR;
using Visma.HR.Domain.Commands.Employee.Actions;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Domain.Commands.Employee.Handlers
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
