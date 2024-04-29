using Visma.Core.Infra.CrossCutting.Common.Sections.Logs;

namespace Visma.Core.Infra.CrossCutting.Common.Sections
{
    public class SettingsDto
    {
        public SecurityDto Security { get; set; }

        public ConnectionStringDto ConnectionStrings { get; set; }

        public LoggingDto Logging { get; set; }
    }
}
