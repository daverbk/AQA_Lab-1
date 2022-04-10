using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace WaitsAlertsWindowsHandlingHomework.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        
        public static IConfiguration Configuration => _configuration.Value;

        static Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }
        
        public static string OnlinerBaseUrl => Configuration[nameof(OnlinerBaseUrl)];
        public static string HerokuAppBaseUrl => Configuration[nameof(HerokuAppBaseUrl)];
        public static string VkontakteBaseUrl => Configuration[nameof(VkontakteBaseUrl)];
        public static string FacebookBaseUrl => Configuration[nameof(FacebookBaseUrl)];
        public static string TwitterBaseUrl => Configuration[nameof(TwitterBaseUrl)];
        public static string BrowserType => Configuration[nameof(BrowserType)];
        public static int WaitTime => int.Parse(Configuration[nameof(WaitTime)]);

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json");
            
            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");
            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}
