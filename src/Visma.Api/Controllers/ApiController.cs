using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Visma.Core.Infra.CrossCutting.Common.Enums;
using Visma.HR.Api.DTOs.Common;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.HR.Api.Controllers
{
    /// <inheritdoc/>
    [Authorize]
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
            var errors = ModelState.Values.SelectMany(value => value.Errors);
            foreach (var error in errors)
            {
                var notificationType = NotificationType.Failure;
                var errorMsg = error.ErrorMessage;
                _notificationContext.Notify(notificationType, errorMsg);
            }
        }

        /// <inheritdoc/>
        protected IActionResult ResponseOk(object obj = null, int totalRecords = 1)
        {
            if (obj == null) totalRecords = 0;

            return Ok(ResponseDto.CreateResponseToData(200, obj, totalRecords));
        }

        /// <inheritdoc/>
        protected IActionResult ResponseBadRequest(string message)
        {
            return BadRequest(message);
        }
    }
}
