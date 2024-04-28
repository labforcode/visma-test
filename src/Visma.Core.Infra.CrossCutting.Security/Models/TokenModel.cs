namespace Visma.Core.Infra.CrossCutting.Security.Models
{
    public class TokenModel
    {
        public string Token { get; set; }

        public DateTime TokenExpiresIn { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiresIn { get; set; }
    }
}
