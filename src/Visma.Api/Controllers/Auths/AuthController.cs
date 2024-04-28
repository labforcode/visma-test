using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Visma.Core.Infra.CrossCutting.Common.Sections;
using Visma.Core.Infra.CrossCutting.Security.Interfaces;
using Visma.HR.Api.Controllers;
using Visma.HR.Domain.Core.Notifications;

namespace Visma.Api.Controllers.Auths
{
    /// <inheritdoc/>
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly ITokenService _tokenService;

        /// <inheritdoc/>
        public AuthController(NotificationContext notificationContext,
                              ITokenService tokenService) : base(notificationContext)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Generate token to consume API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("auth/token")]
        public IActionResult GenerateToken()
        {
            try
            {
                if (Request.Headers.ContainsKey("KeyRequest") is false) return BadRequest("Unable to generate token");

                var keyRequest = Request.Headers["KeyRequest"][0];
                var keySettings = AppSettingsDto.Settings.Security.KeyRequest;

                if (string.IsNullOrEmpty(keyRequest) || keyRequest != keySettings) return BadRequest("Unable to generate token");

                return ResponseOk(_tokenService.GenerateToken());
            }
            catch
            {
                throw;
            }
        }
    }
}
