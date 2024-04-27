using MediatR;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;
using Visma.HR.Domain.Interfaces.Repositories.EFCore.Employees;

namespace Visma.HR.Domain.Commands.Employees.Handlers
{
    public class DeletingEmployeeCommandHandler : CommandHandler,
                                                  IRequestHandler<DeletingEmployeeCommand, bool>
    {
        private readonly IEmployeeEFCoreRepository _employeeRepository;
        private readonly IEmployeeDapperRepository _employeeDapperRepository;

        public DeletingEmployeeCommandHandler(IUnitOfWork uow,
                                              NotificationContext notificationContext,
                                              IEmployeeEFCoreRepository employeeRepository,
                                              IEmployeeDapperRepository employeeDapperRepository) : base(uow, notificationContext)
        {
            _employeeRepository = employeeRepository;
            _employeeDapperRepository = employeeDapperRepository;
        }

        public async Task<bool> Handle(DeletingEmployeeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var isRegistered = await _employeeDapperRepository.CheckEmployeeWasRegistered(command.Id);
                if (isRegistered is false)
                {
                    FailNotify($"Employee not found");
                    return false;
                }

                var employee = await _employeeDapperRepository.GettingEmployee(command.Id);

                _employeeRepository.Remove(employee);
                if (Commit() is false) return false;

                SuccessNotify();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
