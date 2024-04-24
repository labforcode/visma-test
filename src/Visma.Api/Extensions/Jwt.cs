using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Visma.Infra.CrossCutting.Common.Settings;

namespace Visma.Api.Extensions
{
    ///<inheritdoc/>
    public static class Jwt
    {
        ///<inheritdoc/>
        public static void AddJwtConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = AppSettingsDto.Settings.Security.Audience,
                    ValidIssuer = AppSettingsDto.Settings.Security.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsDto.Settings.Security.Key))
                };
            });
        }
    }
}
