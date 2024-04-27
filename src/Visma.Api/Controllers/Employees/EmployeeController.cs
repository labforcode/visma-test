using Microsoft.AspNetCore.Mvc;
using Visma.HR.Application.DTOs.Employees;
using Visma.HR.Application.Interfaces.Employees;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Api.Controllers.Employees
{
    /// <inheritdoc/>
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeAppService _employeeAppService;

        /// <inheritdoc/>
        public EmployeeController(NotificationContext notificationContext,
                                  IEmployeeAppService employeeAppService) : base(notificationContext)
        {
            _employeeAppService = employeeAppService;
        }

        /// <summary>
        /// Adding new employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("employee")]
        public async Task<IActionResult> AddingEmployeeAsync([FromBody] AddingEmployeeDto dto)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    NotifyModelStateErrors();
                    return ResponseOk();
                }

                await _employeeAppService.AddingEmployeeAsync(dto);

                //TO DO melhorar o retorno
                return ResponseCreated();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updating employee
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("employee")]
        public async Task<IActionResult> UpdatingEmployeeAsync([FromBody] UpdatingEmployeeDto dto)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    NotifyModelStateErrors();
                    return ResponseOk();
                }

                await _employeeAppService.UpdatingEmployeeAsync(dto);

                //TO DO melhorar o retorno
                return ResponseOk();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Updating just employee salary
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("employee/salary")]
        public async Task<IActionResult> UpdatingEmployeeSalaryAsync([FromBody] UpdatingEmployeeSalaryDto dto)
        {
            try
            {
                if (ModelState.IsValid is false)
                {
                    NotifyModelStateErrors();
                    return ResponseOk();
                }

                await _employeeAppService.UpdatingEmployeeSalaryAsync(dto);

                //TO DO melhorar o retorno
                return ResponseOk();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deleting employee
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("employee/{id}")]
        public async Task<IActionResult> DeletingEmployeeAsync(Guid id)
        {
            try
            {
                //TO DO
                await _employeeAppService.DeletingEmployeeAsync(id);

                //TO DO melhorar o retorno
                return ResponseOk();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Getting a particular employee by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("employee/{id}")]
        public async Task<IActionResult> GettingEmployeeAsync(Guid id)
        {
            try
            {
                var employee = await _employeeAppService.GettingEmployeeAsync(id);

                return ResponseOk(employee);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Getting employee by filter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startBirthDate"></param>
        /// <param name="endBirthDate"></param>
        /// <param name="bossId"></param>
        /// <param name="pageSize"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GettingEmployeesAsync(string name, DateTime startBirthDate, DateTime endBirthDate, string bossId, int pageSize, int index)
        {
            try
            {
                var totalRecords = 0;
                var employees = await _employeeAppService.GettingEmployeesAsync(name, startBirthDate, endBirthDate, bossId, pageSize, index);
                if(employees != null && employees.Any()) totalRecords = employees.FirstOrDefault().TotalRecords;

                return ResponseOk(employees, totalRecords);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Getting employee count and average salary for particular Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("employee/role/info/{role}")]
        public async Task<IActionResult> GettingInfoRoleAsync(string role)
        {
            try
            {
                await _employeeAppService.GettingInfoRoleAsync(role);

                return ResponseOk();
            }
            catch
            {
                throw;
            }
        }
    }
}
