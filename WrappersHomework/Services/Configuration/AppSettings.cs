using Microsoft.Extensions.Configuration;

namespace WrappersHomework.Services.Configuration
{
    public static class AppSettings
    {
        private static readonly IConfigurationSection AppSettingsJsonSection =
            Configurator.Configuration.GetSection(nameof(AppSettings));
    
        public static string BaseUrl => AppSettingsJsonSection["BaseUrl"];
    
        public static string BrowserType => AppSettingsJsonSection["BrowserType"];
    
        public static int WaitTimeout => int.Parse(AppSettingsJsonSection["WaitTimeout"]);
    }
}
