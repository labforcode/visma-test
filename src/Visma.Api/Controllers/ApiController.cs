using Microsoft.AspNetCore.Mvc;
using Visma.HR.Api.DTOs.Common;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Api.Controllers
{
    /// <inheritdoc/>
    //[Authorize]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly NotificationContext _notificationContext;

        /// <inheritdoc/>
        public ApiController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        /// <inheritdoc/>
        protected void NotifyModelStateErrors()
        {
            //TO DO 
        }

        /// <inheritdoc/>
        protected IActionResult Ok(object obj = null, int totalRecords = 1)
        {
            if (obj == null) totalRecords = 0;

            return Ok(ResponseDto.CreateResponseToData(200, obj, totalRecords));
        }

        /// <inheritdoc/>
        protected IActionResult Created() => Created("", null);
    }
}
