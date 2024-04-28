using FluentAssertions;
using Visma.HR.Domain.Entities.Employees;
using Visma.HR.Infra.CrossCutting.Common.Lists;

namespace Visma.HR.Domain.Tests.Employees
{
    [Collection("EmployeeTests")]
    [Trait("Category", "Domain")]
    public class EmployeeTests : EmployeeFixture
    {
        [Fact]
        public void Create_employee_success_first_name_is_not_empty()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.FirstName.Should().Be(FirstName);
        }

        [Fact]
        public void Create_employee_fail_first_name_empty()
        {
            GenerateProperties();
            FirstName = string.Empty;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.FirstName.Should().Be(FirstName);
        }

        [Fact]
        public void Create_employee_success_last_name_is_not_empty()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.LastName.Should().Be(LastName);
        }

        [Fact]
        public void Create_employee_fail_last_name_empty()
        {
            GenerateProperties();
            LastName = string.Empty;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.LastName.Should().Be(LastName);
        }

        [Fact]
        public void Create_employee_success_first_name_less_50_characters()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.FirstName.Length.Should().BeLessThanOrEqualTo(50);
        }

        [Fact]
        public void Create_employee_fail_first_name_more_50_characters()
        {
            GenerateProperties();
            FirstName = "FD8A6E16D543404AB3A68BC9EFB28BB5A7FAED4D8C8A474BB57";
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void Create_employee_success_last_name_less_50_characters()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.LastName.Length.Should().BeLessThanOrEqualTo(50);
        }

        [Fact]
        public void Create_employee_fail_last_name_more_50_characters()
        {
            GenerateProperties();
            LastName = "FD8A6E16D543404AB3A68BC9EFB28BB5A7FAED4D8C8A474BB57";
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void Create_employee_success_first_name_different_last_name()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.FirstName.Should().NotBeSameAs(LastName);
        }

        [Fact]
        public void Create_employee_fail_first_name_equal_last_name()
        {
            GenerateProperties();
            LastName = FirstName;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeNullOrEmpty();
            sut.FirstName.Should().BeSameAs(LastName);
        }

        [Fact]
        public void Create_employee_success_role_is_not_empty()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.Role.Should().Be(Role);
        }

        [Fact]
        public void Create_employee_fail_role_empty()
        {
            GenerateProperties();
            Role = string.Empty;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.Role.Should().Be(Role);
        }

        [Fact]
        public void Create_employee_success_home_address_is_not_empty()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.HomeAddress.Should().Be(HomeAddress);
        }

        [Fact]
        public void Create_employee_fail_home_address_empty()
        {
            GenerateProperties();
            HomeAddress = string.Empty;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.HomeAddress.Should().Be(HomeAddress);
        }

        [Fact]
        public void Create_employee_success_age_allowed()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.BirthDate.Should().Be(BirthDate);
        }

        [Fact]
        public void Create_employee_fail_age_not_allowed_less_18()
        {
            GenerateProperties();
            BirthDate = GenerateBirthDate(minAge: 1, maxAge: 17);
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.BirthDate.Should().Be(BirthDate);
        }

        [Fact]
        public void Create_employee_fail_age_not_allowed_more_70()
        {
            GenerateProperties();
            BirthDate = GenerateBirthDate(minAge: 71, maxAge: 100);
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.BirthDate.Should().Be(BirthDate);
        }

        [Fact]
        public void Create_employee_success_employement_date_allowed()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.EmploymentDate.Should().Be(EmploymentDate);
        }

        [Fact]
        public void Create_employee_fail_employment_date_not_allowed_less_2000_01_01()
        {
            GenerateProperties();
            EmploymentDate = new DateTime(1999, 12, 31).Date;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.EmploymentDate.Should().Be(EmploymentDate);
        }

        [Fact]
        public void Create_employee_fail_employment_date_not_allowed_more_current_date()
        {
            GenerateProperties();
            EmploymentDate = DateTime.Now.AddDays(1).Date;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.EmploymentDate.Should().Be(EmploymentDate);
        }

        [Fact]
        public void Create_employee_success_currently_salary_allowed()
        {
            GenerateProperties();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.CurrentlySalary.Should().Be(CurrentlySalary);
        }

        [Fact]
        public void Create_employee_fail_currently_salary_not_allowed_less_0()
        {
            GenerateProperties();
            CurrentlySalary = -1;
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeEmpty();
            sut.CurrentlySalary.Should().Be(CurrentlySalary);
        }

        [Fact]
        public void Create_ceo_employee_success()
        {
            GenerateProperties(EmployeeRole.ChiefExecutiveOfficer);
            BossId = Guid.Empty.ToString();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.FirstName.Should().Be(FirstName);
            sut.LastName.Should().Be(LastName);
            sut.BirthDate.Should().Be(BirthDate);
            sut.EmploymentDate.Should().Be(EmploymentDate);
            sut.CurrentlySalary.Should().Be(CurrentlySalary);
            sut.Role.Should().Be(Role);
            sut.HomeAddress.Should().Be(HomeAddress);
            sut.BossId.Should().Be(BossId);
        }

        [Fact]
        public void Create_ceo_employee_fail_with_boss_id()
        {
            GenerateProperties(EmployeeRole.ChiefExecutiveOfficer);
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(EmployeeRole.ChiefMarketingOfficer)]
        [InlineData(EmployeeRole.ChiefOperationsOfficer)]
        [InlineData(EmployeeRole.ChiefInformationOfficer)]
        [InlineData(EmployeeRole.HumanResourcesManager)]
        [InlineData(EmployeeRole.InformationTechnologyManager)]
        [InlineData(EmployeeRole.MarketingManager)]
        [InlineData(EmployeeRole.ProductManager)]
        [InlineData(EmployeeRole.SalesManager)]
        [InlineData(EmployeeRole.AdministrativeAssistant)]
        [InlineData(EmployeeRole.Bookkeeper)]
        [InlineData(EmployeeRole.BusinessAnalyst)]
        [InlineData(EmployeeRole.SalesRepresentative)]
        [InlineData(EmployeeRole.SoftwareEngineer)]
        public void Create_common_employee_success(string role)
        {
            GenerateProperties(role);
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeTrue();
            sut.ValidationResult.Errors.Should().BeEmpty();
            sut.FirstName.Should().Be(FirstName);
            sut.LastName.Should().Be(LastName);
            sut.BirthDate.Should().Be(BirthDate);
            sut.EmploymentDate.Should().Be(EmploymentDate);
            sut.CurrentlySalary.Should().Be(CurrentlySalary);
            sut.Role.Should().Be(Role);
            sut.HomeAddress.Should().Be(HomeAddress);
            sut.BossId.Should().Be(BossId);
        }

        [Theory]
        [InlineData(EmployeeRole.ChiefMarketingOfficer)]
        [InlineData(EmployeeRole.ChiefOperationsOfficer)]
        [InlineData(EmployeeRole.ChiefInformationOfficer)]
        [InlineData(EmployeeRole.HumanResourcesManager)]
        [InlineData(EmployeeRole.InformationTechnologyManager)]
        [InlineData(EmployeeRole.MarketingManager)]
        [InlineData(EmployeeRole.ProductManager)]
        [InlineData(EmployeeRole.SalesManager)]
        [InlineData(EmployeeRole.AdministrativeAssistant)]
        [InlineData(EmployeeRole.Bookkeeper)]
        [InlineData(EmployeeRole.BusinessAnalyst)]
        [InlineData(EmployeeRole.SalesRepresentative)]
        [InlineData(EmployeeRole.SoftwareEngineer)]
        public void Create_common_employee_fail_boss_link(string role)
        {
            GenerateProperties(role);
            BossId = Guid.Empty.ToString();
            var command = GenerateFakeAddingEmployeeCommand();

            var sut = Employee.Create(command);

            sut.Should().NotBeNull();
            sut.IsValid.Should().BeFalse();
            sut.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Update_employee_success_first_name_is_not_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.FirstName.Should().Be(FirstName);
        }

        [Fact]
        public void Update_employee_fail_first_name_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            FirstName = string.Empty;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.FirstName.Should().Be(FirstName);
        }

        [Fact]
        public void Update_employee_success_last_name_is_not_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.LastName.Should().Be(LastName);
        }

        [Fact]
        public void Update_employee_fail_last_name_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            LastName = string.Empty;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.LastName.Should().Be(LastName);
        }

        [Fact]
        public void Update_employee_success_first_name_less_50_characters()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.FirstName.Length.Should().BeLessThanOrEqualTo(50);
        }

        [Fact]
        public void Update_employee_fail_first_name_more_50_characters()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            FirstName = "FD8A6E16D543404AB3A68BC9EFB28BB5A7FAED4D8C8A474BB57";
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void Update_employee_success_last_name_less_50_characters()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.LastName.Length.Should().BeLessThanOrEqualTo(50);
        }

        [Fact]
        public void Update_employee_fail_last_name_more_50_characters()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            LastName = "FD8A6E16D543404AB3A68BC9EFB28BB5A7FAED4D8C8A474BB57";
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void Update_employee_success_first_name_different_last_name()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.FirstName.Should().NotBeSameAs(LastName);
        }

        [Fact]
        public void Update_employee_fail_first_name_equal_last_name()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            LastName = FirstName;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeNullOrEmpty();
            employee.FirstName.Should().BeSameAs(LastName);
        }

        [Fact]
        public void Update_employee_success_role_is_not_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.Role.Should().Be(Role);
        }

        [Fact]
        public void Update_employee_fail_role_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            Role = string.Empty;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.Role.Should().Be(Role);
        }

        [Fact]
        public void Update_employee_success_home_address_is_not_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.HomeAddress.Should().Be(HomeAddress);
        }

        [Fact]
        public void Update_employee_fail_home_address_empty()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            HomeAddress = string.Empty;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.HomeAddress.Should().Be(HomeAddress);
        }

        [Fact]
        public void Update_employee_success_age_allowed()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.BirthDate.Should().Be(BirthDate);
        }

        [Fact]
        public void Update_employee_fail_age_not_allowed_less_18()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            BirthDate = GenerateBirthDate(minAge: 1, maxAge: 17);
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.BirthDate.Should().Be(BirthDate);
        }

        [Fact]
        public void Update_employee_fail_age_not_allowed_more_70()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            BirthDate = GenerateBirthDate(minAge: 71, maxAge: 100);
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.BirthDate.Should().Be(BirthDate);
        }

        [Fact]
        public void Update_employee_success_employement_date_allowed()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.EmploymentDate.Should().Be(EmploymentDate);
        }

        [Fact]
        public void Update_employee_fail_employment_date_not_allowed_less_2000_01_01()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            EmploymentDate = new DateTime(1999, 12, 31).Date;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.EmploymentDate.Should().Be(EmploymentDate);
        }

        [Fact]
        public void Update_employee_fail_employment_date_not_allowed_more_current_date()
        {
            var employee = GenerateEmployee();
            GenerateProperties();
            EmploymentDate = DateTime.Now.AddDays(1).Date;
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.EmploymentDate.Should().Be(EmploymentDate);
        }

        [Fact]
        public void Update_ceo_employee_success()
        {
            var employee = GenerateEmployee(EmployeeRole.ChiefExecutiveOfficer);
            GenerateProperties(EmployeeRole.ChiefExecutiveOfficer);
            BossId = Guid.Empty.ToString();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.FirstName.Should().Be(FirstName);
            employee.LastName.Should().Be(LastName);
            employee.BirthDate.Should().Be(BirthDate);
            employee.EmploymentDate.Should().Be(EmploymentDate);
            employee.Role.Should().Be(Role);
            employee.HomeAddress.Should().Be(HomeAddress);
            employee.BossId.Should().Be(BossId);
        }

        [Fact]
        public void Update_ceo_employee_fail_with_boss_id()
        {
            var employee = GenerateEmployee(EmployeeRole.ChiefExecutiveOfficer);
            GenerateProperties(EmployeeRole.ChiefExecutiveOfficer);
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [InlineData(EmployeeRole.ChiefMarketingOfficer)]
        [InlineData(EmployeeRole.ChiefOperationsOfficer)]
        [InlineData(EmployeeRole.ChiefInformationOfficer)]
        [InlineData(EmployeeRole.HumanResourcesManager)]
        [InlineData(EmployeeRole.InformationTechnologyManager)]
        [InlineData(EmployeeRole.MarketingManager)]
        [InlineData(EmployeeRole.ProductManager)]
        [InlineData(EmployeeRole.SalesManager)]
        [InlineData(EmployeeRole.AdministrativeAssistant)]
        [InlineData(EmployeeRole.Bookkeeper)]
        [InlineData(EmployeeRole.BusinessAnalyst)]
        [InlineData(EmployeeRole.SalesRepresentative)]
        [InlineData(EmployeeRole.SoftwareEngineer)]
        public void Update_common_employee_success(string role)
        {
            var employee = GenerateEmployee();
            GenerateProperties(role);
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.FirstName.Should().Be(FirstName);
            employee.LastName.Should().Be(LastName);
            employee.BirthDate.Should().Be(BirthDate);
            employee.EmploymentDate.Should().Be(EmploymentDate);
            employee.Role.Should().Be(Role);
            employee.HomeAddress.Should().Be(HomeAddress);
        }

        [Theory]
        [InlineData(EmployeeRole.ChiefMarketingOfficer)]
        [InlineData(EmployeeRole.ChiefOperationsOfficer)]
        [InlineData(EmployeeRole.ChiefInformationOfficer)]
        [InlineData(EmployeeRole.HumanResourcesManager)]
        [InlineData(EmployeeRole.InformationTechnologyManager)]
        [InlineData(EmployeeRole.MarketingManager)]
        [InlineData(EmployeeRole.ProductManager)]
        [InlineData(EmployeeRole.SalesManager)]
        [InlineData(EmployeeRole.AdministrativeAssistant)]
        [InlineData(EmployeeRole.Bookkeeper)]
        [InlineData(EmployeeRole.BusinessAnalyst)]
        [InlineData(EmployeeRole.SalesRepresentative)]
        [InlineData(EmployeeRole.SoftwareEngineer)]
        public void Update_common_employee_fail_boss_link(string role)
        {
            var employee = GenerateEmployee();
            GenerateProperties(role);
            BossId = Guid.Empty.ToString();
            var command = GenerateFakeUpdatingEmployeeCommand(employee.Id);

            employee.Update(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Update_employee_currently_salary_success_currently_salary_allowed()
        {
            var employee = GenerateEmployee();
            var currentlySalary = GenerateCurrentlySalary();
            var command = GenerateFakeUpdatingEmployeeCurrentlySalaryCommand(employee.Id, currentlySalary);

            employee.UpdateSalary(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeTrue();
            employee.ValidationResult.Errors.Should().BeEmpty();
            employee.CurrentlySalary.Should().Be(CurrentlySalary);
        }

        [Fact]
        public void Update_employee_currently_salary_fail_currently_salary_not_allowed_less_0()
        {
            var employee = GenerateEmployee();
            var currentlySalary = -1;
            var command = GenerateFakeUpdatingEmployeeCurrentlySalaryCommand(employee.Id, currentlySalary);

            employee.UpdateSalary(command);

            employee.Should().NotBeNull();
            employee.IsValid.Should().BeFalse();
            employee.ValidationResult.Errors.Should().NotBeEmpty();
            employee.CurrentlySalary.Should().Be(CurrentlySalary);
        }

        [Fact]
        public void Check_if_is_CEO_success()
        {
            var employee = GenerateEmployee(EmployeeRole.ChiefExecutiveOfficer);

            var sut = employee.CheckIfIsCEO();

            sut.Should().BeTrue();
        }

        [Fact]
        public void Check_if_is_not_CEO_success()
        {
            var employee = GenerateEmployee();

            var sut = employee.CheckIfIsCEO();

            sut.Should().BeFalse();
        }

        [Fact]
        public void Check_if_age_is_allowed_success()
        {
            var employee = GenerateEmployee();

            var sut = employee.CheckIfAgeIsAllowed();

            sut.Should().BeTrue();
        }

        [Fact]
        public void Check_if_age_is_allowed_failt_age_less_18()
        {
            var minAge = 17;
            var birthDate = new DateTime(DateTime.Now.Year - minAge, 1, 1);
            var employee = GenerateEmployee(birthDate: birthDate);

            var sut = employee.CheckIfAgeIsAllowed();

            sut.Should().BeFalse();
        }

        [Fact]
        public void Check_if_age_is_allowed_fail_age_more_70()
        {
            var maxAge = 71;
            var birthDate = new DateTime(DateTime.Now.Year - maxAge, 1, 1);
            var employee = GenerateEmployee(birthDate: birthDate);

            var sut = employee.CheckIfAgeIsAllowed();

            sut.Should().BeFalse();
        }

        [Fact]
        public void Check_min_employment_date_allowed_success()
        {
            var employee = GenerateEmployee();

            var sut = employee.CheckMinEmploymentDateAllowed();

            sut.Should().BeTrue();
        }

        [Fact]
        public void Check_min_employment_date_allowed_fail_employment_date_less_2000_01_01()
        {
            var employmentDate = new DateTime(1999, 1, 1);
            var employee = GenerateEmployee(employmentDate: employmentDate);

            var sut = employee.CheckMinEmploymentDateAllowed();

            sut.Should().BeFalse();
        }

        [Fact]
        public void Check_max_employment_date_allowed_success()
        {
            var employee = GenerateEmployee();

            var sut = employee.CheckMaxEmploymentDateAllowed();

            sut.Should().BeTrue();
        }

        [Fact]
        public void Check_max_employment_date_allowed_fail_employment_date_more_current_date()
        {
            var employmentDate = DateTime.Now.AddDays(1);
            var employee = GenerateEmployee(employmentDate: employmentDate);

            var sut = employee.CheckMaxEmploymentDateAllowed();

            sut.Should().BeFalse();
        }

        [Fact]
        public void Check_min_currently_salary_allowed_success()
        {
            var employee = GenerateEmployee();

            var sut = employee.CheckMinCurrentSalaryAllowed();

            sut.Should().BeTrue();
        }

        [Fact]
        public void Check_min_currently_salary_allowed_fail_currently_salary_less_zero()
        {
            var currentlySalary = -1;
            var employee = GenerateEmployee(currentlySalary: currentlySalary);

            var sut = employee.CheckMinCurrentSalaryAllowed();

            sut.Should().BeFalse();
        }
    }
}
