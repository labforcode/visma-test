using Microsoft.Extensions.Configuration;

namespace Visma.Core.Infra.CrossCutting.Common.Sections
{
    public class AppSettingsDto
    {
        public static SettingsDto? Settings { get; private set; }

        public static void ParseAppSettings(IConfiguration configuration) => Settings = configuration.GetSection("Settings").Get<SettingsDto>();
    }
}
