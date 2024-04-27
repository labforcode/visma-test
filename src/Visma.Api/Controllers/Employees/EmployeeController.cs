using Microsoft.AspNetCore.Mvc;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Api.Controllers.Employees
{
    /// <inheritdoc/>
    public class EmployeeController : ApiController
    {
        /// <inheritdoc/>
        public EmployeeController(NotificationContext notificationContext) : base(notificationContext)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("employee")]
        public async Task<IActionResult> AddingEmployeeAsync()
        {
            try
            {


                return Ok();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("employee")]
        public async Task<IActionResult> UpdatingEmployeeAsync()
        {
            try
            {


                return Ok();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPatch]
        [Route("employee/salary")]
        public async Task<IActionResult> UpdatingEmployeeSalaryAsync()
        {
            try
            {


                return Ok();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("employee/{id}")]
        public async Task<IActionResult> DeletingEmployeeAsync(Guid id)
        {
            try
            {


                return Ok();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        [Route("employee/{id}")]
        public async Task<IActionResult> GettingEmployeeAsync(Guid id)
        {
            try
            {


                return Ok();
            }
            catch
            {
                throw;
            }
        }

    }
}
