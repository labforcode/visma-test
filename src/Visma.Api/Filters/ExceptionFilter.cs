using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Visma.Core.Infra.CrossCutting.Common.Constants;
using Visma.Core.Infra.CrossCutting.Logging.Services;
using Visma.HR.Api.DTOs.Common;

namespace Visma.Api.Filters
{
    /// <inheritdoc/>
    public class ExceptionFilter : IExceptionFilter
    {
        /// <inheritdoc/>
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            var message = context.Exception.Message;
            var stackTrace = context.Exception.StackTrace;
            LogService.RegisterLog(message, stackTrace);

            context.Result = new JsonResult(ResponseDto.CreateResponseToError(500, DefaultMessages.Exception)) { StatusCode = 500 };
        }
    }
}
