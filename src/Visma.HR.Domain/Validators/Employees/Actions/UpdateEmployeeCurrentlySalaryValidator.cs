namespace Visma.HR.Domain.Validators.Employees.Actions
{
    public class UpdateEmployeeCurrentlySalaryValidator : EmployeeValidator
    {
        public UpdateEmployeeCurrentlySalaryValidator()
        {
            ValidateMinCurrentSalaryAllowed();
        }
    }
}
