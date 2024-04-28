using Microsoft.AspNetCore.Authentication.JwtBearer;
using Visma.Core.Infra.CrossCutting.Security.Configurations;

namespace Visma.HR.Api.Extensions
{
    ///<inheritdoc/>
    public static class Jwt
    {
        ///<inheritdoc/>
        public static void AddJwtConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtConfiguration.GetTokenConfiguration();
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
