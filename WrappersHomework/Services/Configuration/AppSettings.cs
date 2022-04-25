using Microsoft.Extensions.Configuration;

namespace WrappersHomework.Services.Configuration
{
    public static class AppSettings
    {
        private static readonly IConfigurationSection AppSettingsJsonClass =
            Configurator.Configuration.GetSection(nameof(AppSettings));
    
        public static string BaseUrl => AppSettingsJsonClass["BaseUrl"];
    
        public static string BrowserType => AppSettingsJsonClass["BrowserType"];
    
        public static int WaitTimeout => int.Parse(AppSettingsJsonClass["WaitTimeout"]);
    }
}
