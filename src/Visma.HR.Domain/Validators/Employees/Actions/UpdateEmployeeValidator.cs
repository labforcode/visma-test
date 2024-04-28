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
            ValidateRoleIsEmpty();
            ValidateHomeAddressIsEmpty();
            ValidateIfCEO();
            ValidateIfCommonEmployee();
            ValidateEmployeeAge();
            ValidateMinEmploymentDate();
            ValidateMaxEmploymentDate();
            ValidateMinCurrentSalaryAllowed();
        }
    }
}
