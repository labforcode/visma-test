namespace Visma.HR.Domain.Validators.Employees.Actions
{
    public class CreateEmployeeValidator : EmployeeValidator
    {
        public CreateEmployeeValidator()
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
