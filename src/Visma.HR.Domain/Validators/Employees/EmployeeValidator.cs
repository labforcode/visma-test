using FluentValidation;
using Visma.HR.Domain.Core.Validators;
using Visma.HR.Domain.Entities.Employees;

namespace Visma.HR.Domain.Validators.Employees
{
    public class EmployeeValidator : Validator<Employee>
    {
        protected void ValidateFirstNameIsEmpty()
        {
            RuleFor(employee => employee.FirstName)
                .NotEmpty()
                .WithMessage("The First Name cannot be empty");
        }

        protected void ValidateLastNameIsEmpty()
        {
            RuleFor(employee => employee.LastName)
                .NotEmpty()
                .WithMessage("The Last Name cannot be empty");
        }

        protected void ValidateFirstNameLength()
        {
            RuleFor(employee => employee.FirstName.Length)
                .LessThanOrEqualTo(50)
                .WithMessage("The First Name cannot be greater than 50 characters");
        }

        protected void ValidateLastNameLength()
        {
            RuleFor(employee => employee.LastName.Length)
                .LessThanOrEqualTo(50)
                .WithMessage("The Last Name cannot be greater than 50 characters");
        }

        protected void ValidateDifferenceBetweenFirstNameAndLastName()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.FirstName == employee.LastName)
                        context.AddFailure("First Name should be different of Last Name");
                });
        }

        protected void ValidateRoleIsEmpty()
        {
            RuleFor(employee => employee.Role)
                .NotEmpty()
                .WithMessage("Role cannot be empty");
        }

        protected void ValidateHomeAddressIsEmpty()
        {
            RuleFor(employee => employee.HomeAddress)
                .NotEmpty()
                .WithMessage("Home address cannot be empty");
        }

        protected void ValidateIfCEO()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.CheckIfIsCEO() && employee.BossId != Guid.Empty)
                        context.AddFailure("CEO has no Boss");
                });
        }

        protected void ValidateIfCommonEmployee()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.CheckIfIsCEO() is false && employee.BossId == Guid.Empty)
                        context.AddFailure("Is necessary to say who's the Boss");
                });
        }

        protected void ValidateEmployeeAge()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.CheckIfAgeIsAllowed() is false)
                        context.AddFailure("Employee must be at least 18 years old and not older than 70 years");
                });
        }

        protected void ValidateMinEmploymentDate()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.CheckMinEmploymentDateAllowed() is false)
                        context.AddFailure("Employment Date cannot be earlier than 2000-01-01");
                });
        }

        protected void ValidateMaxEmploymentDate()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.CheckMaxEmploymentDateAllowed() is false)
                        context.AddFailure("Employment Date cannot be a future date");
                });
        }

        protected void ValidateMinCurrentSalaryAllowed()
        {
            RuleFor(employee => employee)
                .Custom((employee, context) =>
                {
                    if (employee.CheckMinCurrentSalaryAllowed() is false)
                        context.AddFailure("Current salary must be non-negative");
                });
        }
    }
}
