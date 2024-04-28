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
            ValidateCEO();
            ValidateCommonEmployee();
            ValidateEmployeeAge();
            ValidateMinEmploymentDate();
            ValidateMaxEmploymentDate();
            ValidateMinCurrentSalaryAllowed();
        }
    }
}
