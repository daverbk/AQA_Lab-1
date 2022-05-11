using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace AllureExtensionsFluentAssertionsHomework.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _configuration;
        
        public static IConfiguration Configuration => _configuration.Value;

        static Configurator()
        {
            _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }
        
        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        public static string BrowserType => Configuration[nameof(BrowserType)];
        public static string UserName => Configuration[nameof(UserName)];
        public static string Password => Configuration[nameof(Password)];
        public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);

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
