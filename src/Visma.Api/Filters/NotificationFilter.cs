using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Visma.Api.DTOs.Common;
using Visma.Domain.Core.Notifications;
using Visma.Infra.CrossCutting.Common.Constants;
using Visma.Infra.CrossCutting.Common.Enums;

namespace Visma.Api.Filters
{
    /// <inheritdoc/>
    public class NotificationFilter : IAsyncResultFilter
    {
        /// <inheritdoc/>
        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        private readonly NotificationContext _notificationContext;

        /// <inheritdoc/>
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                await ChangeHttpContext(context);
                return;
            }

            await next();
        }

        private async Task ChangeHttpContext(ResultExecutingContext context)
        {
            var type = _notificationContext.GetTypeNotifications();
            var code = DefineStatusCode(type);
            var response = DefineResponse(type);
            context.HttpContext.Response.ContentType = MediaType.JSON;
            context.HttpContext.Response.StatusCode = code;
            await context.HttpContext.Response.WriteAsync(response);
            _notificationContext.ClearNotifications();
        }

        private int DefineStatusCode(NotificationType type) => type switch
        {
            NotificationType.Failure => (int)HttpStatusCode.BadRequest,
            NotificationType.Exception => (int)HttpStatusCode.InternalServerError,
            _ => (int)HttpStatusCode.OK
        };

        private string DefineResponse(NotificationType type)
        {
            var code = DefineStatusCode(type);
            var message = _notificationContext.GetNotification().FirstOrDefault();
            return type switch
            {
                NotificationType.Success => ResponseDto.CreateResponseToNotification(code, message),
                _ => ResponseDto.CreateResponseToError(code, message)
            };
        }
    }
}
