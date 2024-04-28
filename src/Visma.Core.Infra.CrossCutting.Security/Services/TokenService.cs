using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Visma.Core.Infra.CrossCutting.Common.Sections;
using Visma.Core.Infra.CrossCutting.Security.Interfaces;
using Visma.Core.Infra.CrossCutting.Security.Models;

namespace Visma.Core.Infra.CrossCutting.Security.Services
{
    public class TokenService : ITokenService
    {
        /// <inheritdoc/>
        public TokenModel GenerateToken()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettingsDto.Settings.Security.Key);
                var tokenValidForMinutes = Convert.ToInt32(AppSettingsDto.Settings.Security.TokenValidForMinutes);
                var refreshTokenValidForMinutes = Convert.ToInt32(AppSettingsDto.Settings.Security.RefreshTokenValidForMinutes);
                var currentDate = DateTime.Now;
                var tokenExpiresIn = currentDate.AddMinutes(tokenValidForMinutes);
                var refreshToken = GenerateRefreshToken();
                var refreshTokenExpiresIn = tokenExpiresIn.AddMinutes(refreshTokenValidForMinutes);
                var claims = ObterClaims();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    IssuedAt = currentDate,
                    NotBefore = currentDate,
                    Expires = tokenExpiresIn,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Subject = new ClaimsIdentity(claims)
                };

                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return new TokenModel
                {
                    Token = token,
                    TokenExpiresIn = tokenExpiresIn,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiresIn = refreshTokenExpiresIn,
                };
            }
            catch
            {
                throw;
            }
        }

        private List<Claim> ObterClaims()
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, AppSettingsDto.Settings.Security.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
            };
        }

        private string GenerateRefreshToken()
        {
            var key = string.Empty;
            for (int i = 0; i < 5; i++) { key += Guid.NewGuid().ToString(); }

            key = key.Replace("-", "");
            var keyBytes = Encoding.UTF8.GetBytes(key);

            return Convert.ToBase64String(keyBytes);
        }
    }
}

