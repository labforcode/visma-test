using Visma.Infra.CrossCutting.Common.Settings.Sections.Logs;

namespace Visma.Infra.CrossCutting.Common.Settings.Sections
{
    public class SettingsDto
    {
        /// <inheritdoc/>
        public SecurityDto Security { get; set; }

        /// <inheritdoc/>
        public ConnectionStringDto ConnectionStrings { get; set; }

        /// <inheritdoc/>
        public LoggingDto Logging { get; set; }
    }
}
