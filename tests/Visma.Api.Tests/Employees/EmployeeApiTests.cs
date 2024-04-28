using FluentAssertions;
using Visma.Api.Tests.Base.DTOs;
using Visma.Api.Tests.Base.Enums;

namespace Visma.Api.Tests.Employees
{
    public class EmployeeApiTests : EmployeeApiFixture
    {
        [Fact]
        public async Task Register_employee_success()
        {
            var employee = GenerateFakeEmployee();
            var payload = RequestDto.GenerateRequestDto(RequestType.HttpPost, "employee", employee);

            var sut = await HandleRequestAsync(payload);

            sut.Should().BeNull();
        }
    }
}
