using Microsoft.AspNetCore.Mvc;
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
    }
}
