namespace Visma.HR.Infra.CrossCutting.Common.Settings.Sections
{
    public class SecurityDto
    {
        /// <inheritdoc/>
        public string Key { get; set; }

        /// <inheritdoc/>
        public string Issuer { get; set; }

        /// <inheritdoc/>
        public string Audience { get; set; }

        /// <inheritdoc/>
        public string Subject { get; set; }

        /// <inheritdoc/>
        public int TokenExpiresIn { get; set; }

        /// <inheritdoc/>
        public int RefreshTokenExpiresIn { get; set; }
    }
}
