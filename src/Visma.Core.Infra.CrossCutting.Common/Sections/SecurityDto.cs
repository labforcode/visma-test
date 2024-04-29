namespace Visma.Core.Infra.CrossCutting.Common.Sections
{
    public class SecurityDto
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Subject { get; set; }

        public int TokenValidForMinutes { get; set; }

        public int RefreshTokenValidForMinutes { get; set; }

        public string KeyRequest { get; set; }
    }
}
