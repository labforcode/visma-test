using Microsoft.IdentityModel.Tokens;
using System.Text;
using Visma.Core.Infra.CrossCutting.Common.Sections;

namespace Visma.Core.Infra.CrossCutting.Security.Configurations
{
    public class JwtConfiguration
    {
        public static TokenValidationParameters GetTokenConfiguration()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = AppSettingsDto.Settings.Security.Issuer,
                ValidAudience = AppSettingsDto.Settings.Security.Audience,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettingsDto.Settings.Security.Key))
            };
        }
    }
}
