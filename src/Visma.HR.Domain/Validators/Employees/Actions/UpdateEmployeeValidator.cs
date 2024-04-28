namespace Visma.HR.Domain.Validators.Employees.Actions
{
    public class UpdateEmployeeValidator : EmployeeValidator
    {
        public UpdateEmployeeValidator()
        {
            ValidateFirstNameIsEmpty();
            ValidateLastNameIsEmpty();
            ValidateFirstNameLength();
            ValidateLastNameLength();
            ValidateDifferenceBetweenFirstNameAndLastName();
            ValidateCEO();
            ValidateCommonEmployee();
            ValidateEmployeeAge();
            ValidateMinEmploymentDate();
            ValidateMaxEmploymentDate();
            ValidateMinCurrentSalaryAllowed();
        }
    }
}
