using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PageObjectHomework.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;

        public static string BaseUrl => Configuration[nameof(BaseUrl)];
        public static string Username => Configuration[nameof(Username)];
        public static string Password => Configuration[nameof(Password)];
        public static string BrowserType => Configuration[nameof(BrowserType)];

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

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
