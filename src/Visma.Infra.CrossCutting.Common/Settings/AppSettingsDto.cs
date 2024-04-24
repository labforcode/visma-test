﻿using Microsoft.Extensions.Configuration;
using Visma.Infra.CrossCutting.Common.Settings.Sections;

namespace Visma.Infra.CrossCutting.Common.Settings
{
    public class AppSettingsDto
    {
        public static SettingsDto? Settings { get; private set; }

        /// <inheritdoc/>
        public static void ParseAppSettings(IConfiguration configuration) => Settings = configuration.GetSection("Settings").Get<SettingsDto>();
    }
}
