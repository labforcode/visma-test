using MediatR;
using Visma.HR.Domain.Commands.Employees.Actions;
using Visma.HR.Domain.Core.Interfaces.UoW;
using Visma.HR.Domain.Core.Notifications;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Domain.Interfaces.Repositories.Dapper.Employees;
using Visma.HR.Domain.Interfaces.Repositories.EFCore.Employees;

namespace Visma.HR.Domain.Commands.Employees.Handlers
{
    public class AddingEmployeeCommandHandler : CommandHandler,
                                                IRequestHandler<AddingEmployeeCommand, bool>
    {
        private readonly IEmployeeEFCoreRepository _employeeRepository;
        private readonly IEmployeeDapperRepository _employeeDapperRepository;
        public AddingEmployeeCommandHandler(IUnitOfWork uow,
                                            NotificationContext notificationContext,
                                            IEmployeeEFCoreRepository employeeRepository,
                                            IEmployeeDapperRepository employeeDapperRepository) : base(uow, notificationContext)
        {
            _employeeRepository = employeeRepository;
            _employeeDapperRepository = employeeDapperRepository;
        }

        public async Task<bool> Handle(AddingEmployeeCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var employee = Employee.Create(command);
                if (employee.IsValid is false)
                {
                    FailNotify(employee.ValidationResult);
                    return false;
                }

                var isRegistered = await _employeeDapperRepository.CheckEmployeeWasRegistered(employee.FirstName, employee.LastName);
                if (isRegistered)
                {
                    FailNotify($"There is already an employee with the name {employee.FirstName} {employee.LastName}");
                    return false;
                }

                var ceoRegistered = await _employeeDapperRepository.CheckCEOWasRegistered();
                if (ceoRegistered)
                {
                    FailNotify($"There can be only 1 employee with CEO role");
                    return false;
                }

                _employeeRepository.Add(employee);
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
