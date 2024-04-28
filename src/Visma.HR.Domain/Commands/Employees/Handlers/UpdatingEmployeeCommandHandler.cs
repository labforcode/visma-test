using MediatR;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;
using Visma.HR.Domain.Interfaces.Repositories.EFCore.Employees;

namespace Visma.HR.Domain.Commands.Employees.Handlers
{
    public class UpdatingEmployeeCommandHandler : CommandHandler,
                                                  IRequestHandler<UpdatingEmployeeCommand, bool>
    {
        private readonly IEmployeeEFCoreRepository _employeeRepository;
        private readonly IEmployeeDapperRepository _employeeDapperRepository;

        public UpdatingEmployeeCommandHandler(IUnitOfWork uow,
                                              NotificationContext notificationContext,
                                              IEmployeeEFCoreRepository employeeRepository,
                                              IEmployeeDapperRepository employeeDapperRepository) : base(uow, notificationContext)
        {
            _employeeRepository = employeeRepository;
            _employeeDapperRepository = employeeDapperRepository;
        }

        public async Task<bool> Handle(UpdatingEmployeeCommand command, CancellationToken cancellationToken)
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
                employee.Update(command);

                var ceoRegistered = await _employeeDapperRepository.CheckCEOWasRegistered(employee.Id);
                if (ceoRegistered)
                {
                    FailNotify($"There can be only 1 employee with CEO role");
                    return false;
                }

                _employeeRepository.Update(employee);
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
